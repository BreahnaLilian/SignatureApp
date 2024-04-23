using SignatureApplication.Users.Query.GetUserList;

namespace SignatureApplication.Users.ViewModels
{
    public class UsersViewModel
    {
        public ICollection<UserVm> Users { get; set; }
    }
}
