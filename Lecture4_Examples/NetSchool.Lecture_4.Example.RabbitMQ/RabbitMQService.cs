using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetSchool.Lecture_4.Example.RabbitMQ
{
    public class RabbitMqService
    {
        private readonly string connectionString = "amqp://guest:guest@localhost:5672/";
        private readonly object connectionLock = new();

        private IModel channel;
        private IConnection connection;

        public void Dispose()
        {
            channel?.Close();
            connection?.Close();
        }

        public IModel GetChannel()
        {
            return channel;
        }

        public void RegisterListener(string queueName, EventHandler<BasicDeliverEventArgs> onReceive)
        {
            AddQueue(queueName);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (ch, ea) => {
                onReceive?.Invoke(ch, ea);
                channel.BasicAck(ea.DeliveryTag, false);
            };
            //onReceive;

            channel.BasicConsume(queueName, false, consumer);
        }

        public void Publish<T>(string queueName, T data)
        {
            AddQueue(queueName);

            var message = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data));

            var properties = channel.CreateBasicProperties();

            channel.BasicPublish(string.Empty, queueName, properties, message);
        }

        private void Connect()
        {
            lock (connectionLock)
            {
                if (connection?.IsOpen ?? false)
                    return;

                var factory = new ConnectionFactory
                {
                    Uri = new Uri(connectionString),

                    AutomaticRecoveryEnabled = true,
                    NetworkRecoveryInterval = TimeSpan.FromSeconds(5)
                };

                var retriesCount = 0;
                while (retriesCount < 15)
                    try
                    {
                        if (connection == null)
                        {
                            connection = factory.CreateConnection();
                        }

                        if (channel == null)
                        {
                            channel = connection.CreateModel();
                            channel.BasicQos(0, 1, false);
                        }

                        break;
                    }
                    catch (BrokerUnreachableException)
                    {
                        Task.Delay(1000).Wait();
                        retriesCount++;
                    }
            }
        }

        private void AddQueue(string queueName)
        {
            Connect();
            channel.QueueDeclare(queueName, true, false, false, null);
        }
    }
}