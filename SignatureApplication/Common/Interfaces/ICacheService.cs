namespace SignatureApplication.Common.Interfaces
{
    public interface ICacheService
    {
        T GetData<T>(string key);
        Task<T> GetDataAsync<T>(string key, CancellationToken cancellationToken);
        bool SetData<T>(string key, T value, DateTimeOffset expirationTime);
        Task<bool> SetDataAsync<T>(string key, T value, DateTimeOffset expirationTime, CancellationToken cancellationToken);
        object RemoveData(string key);
        Task<object> RemoveDataAsync(string key, CancellationToken cancellationToken);
    }
}
