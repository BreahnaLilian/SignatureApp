using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using SignatureApplication.Common.Interfaces;

namespace SignatureInfrastructure.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache distributedCache;

        public CacheService(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public T GetData<T>(string key)
        {
            var value = distributedCache.GetString(key);

            if (!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value);
            }

            return default;
        }

        public async Task<T> GetDataAsync<T>(string key, CancellationToken cancellationToken)
        {
            var value = await distributedCache.GetStringAsync(key, cancellationToken);
            
            if (!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value);
            }
            
            return default;
        }

        public object RemoveData(string key)
        {
            var exists = distributedCache.GetString(key);

            if (!string.IsNullOrEmpty(exists))
            {
                distributedCache.Remove(key);
            }

            return false;
        }
        
        public async Task<object> RemoveDataAsync(string key, CancellationToken cancellationToken)
        {
            var exists = await distributedCache.GetStringAsync(key, cancellationToken);

            if (!string.IsNullOrEmpty(exists))
            {
                await distributedCache.RemoveAsync(key, cancellationToken);
            }

            return false;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            var expiryDate = expirationTime.DateTime.Subtract(DateTime.Now);
            distributedCache.SetString(key, JsonSerializer.Serialize(value), new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = expiryDate,
            });

            return true;
        }
        
        public async Task<bool> SetDataAsync<T>(string key, T value, DateTimeOffset expirationTime, CancellationToken cancellationToken)
        {
            var expiryDate = expirationTime.DateTime.Subtract(DateTime.Now);
            await distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value), new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = expiryDate,
            }, cancellationToken);

            return true;
        }
    }
}
