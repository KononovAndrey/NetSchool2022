using StackExchange.Redis;
using System;

namespace NetSchool.Lecture_4.Example.Redis
{
    public class RedisService
    {
        private IDatabase cacheDB { get; set; }

        private static string connectionString = "localhost:6379,allowAdmin=true,abortConnect=false";

        public RedisService()
        {
            cacheDB = Connection.GetDatabase();
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(connectionString);
        });

        private static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

        public bool Delete(string key)
        {
            return cacheDB.KeyDelete(key);
        }

        public T Get<T>(string key)
        {
            try
            {
                // Get data
                string cached_data = cacheDB.StringGet(key);
                if (cached_data is null)
                    return default(T);

                var data = System.Text.Json.JsonSerializer.Deserialize<T>(cached_data);

                // Update lifetime
                //SetStoreTime(key);

                // Return result
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Can`t get data from cache for {key}. {ex.Message}");
            }
        }

        public bool Put<T>(string key, T data, int storeTime = 60*60)
        {
            return cacheDB.StringSet(key, System.Text.Json.JsonSerializer.Serialize(data), TimeSpan.FromSeconds(storeTime));
        }

        private void SetStoreTime(string key, int storeTime = 60*60)
        {
            cacheDB.KeyExpire(key, TimeSpan.FromSeconds(storeTime));
        }
    }
}
