namespace DSRNetSchool.Services.Cache;

public interface ICacheService
{
    /// <summary>
    /// Generate unique key for cache storage
    /// </summary>
    /// <returns></returns>
    string KeyGenerate();

    /// <summary>
    /// Put data to cache
    /// </summary>
    /// <param name="key">Cache key</param>
    /// <param name="data">Data for put</param>
    /// <param name="storeTime">Time for store data</param>
    Task<bool> Put<T>(string key, T data, TimeSpan? storeTime = null);

    /// <summary>
    /// Set store time for data from DateTime.UtcNow
    /// </summary>
    /// <param name="key">Cache key</param>
    /// <param name="storeTime">Time for store data</param>
    Task SetStoreTime(string key, TimeSpan? storeTime = null);

    /// <summary>
    /// Extract data from cache
    /// </summary>
    /// <typeparam name="T">Type of data</typeparam>
    /// <param name="key">Cache key</param>
    /// <param name="resetLifeTime">True if need to reset life time, false otherwise. False by default</param>
    Task<T> Get<T>(string key, bool resetLifeTime = true);

    /// <summary>
    /// Remove data from cahce
    /// </summary>
    /// <param name="key">Cache key</param>
    Task<bool> Delete(string key);
}
