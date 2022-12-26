namespace DSRNetSchool.Services.RabbitMq;

using System.Threading.Tasks;

public delegate Task OnDataReceiveEvent<T>(T data);

public interface IRabbitMq
{
    Task Subscribe<T>(string queueName, OnDataReceiveEvent<T> onReceive);

    Task PushAsync<T>(string queueName, T data);
}
