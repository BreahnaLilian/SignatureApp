using MediatR;
using SignatureApplication.Users.ViewModels;

namespace SignatureApplication.Users.Query.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<DetailsUserViewModel>
    {
        public Guid Id { get; set; }
    }
}
