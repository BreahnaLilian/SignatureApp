using MediatR;
using SignatureApplication.Users.ViewModels;

namespace SignatureApplication.Users.Query.GetUserList
{
    public class GetUserListQuery : IRequest<UsersViewModel>
    {
    }
}
