using static SignatureCommon.Enums;

namespace SignatureApplication.Users.Query.GetUserList
{
    public class UserVm
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserStatus Status { get; set; }
    }
}
