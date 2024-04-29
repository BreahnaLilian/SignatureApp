using Microsoft.Extensions.Caching.Distributed;
using SignatureApplication.Common.Interfaces;
using System.Text.Json;

namespace SignatureInfrastructure.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache distributedCache;

        public CacheService(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public T GetData<T>(string key, CancellationToken cancellationToken)
        {
            var value = distributedCache.GetString(key);

            if (!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value);
            }

            return default;
        }

        public object RemoveData(string key, CancellationToken cancellationToken)
        {
            var exists = distributedCache.GetString(key);

            if (!string.IsNullOrEmpty(exists))
            {
                distributedCache.Remove(key);
            }

            return false;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime, CancellationToken cancellationToken)
        {
            var expiryDate = expirationTime.DateTime.Subtract(DateTime.Now);
            distributedCache.SetString(key, JsonSerializer.Serialize(value), new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = expiryDate,
            });

            return true;
        }
    }
}
