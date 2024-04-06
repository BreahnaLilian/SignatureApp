namespace SignatureApplication.Common.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
        string Email { get; set; }
        string MobilePhone { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
        bool IsAuthenticated { get; }
    }
}
