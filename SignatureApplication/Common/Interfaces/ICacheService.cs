namespace SignatureApplication.Common.Interfaces
{
    public interface ICacheService
    {
        T GetData<T>(string key, CancellationToken cancellationToken);
        bool SetData<T>(string key, T value, DateTimeOffset expirationTime, CancellationToken cancellationToken);
        object RemoveData(string key, CancellationToken cancellationToken);
    }
}
