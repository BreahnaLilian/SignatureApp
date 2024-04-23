using MediatR;
using SignatureApplication.Users.ViewModels;

namespace SignatureApplication.Users.Query.GetUserUpdate
{
    public class GetUserUpdateQuery : IRequest<UpdateUserViewModel>
    {
        public Guid Id { get; set; }
    }
}
