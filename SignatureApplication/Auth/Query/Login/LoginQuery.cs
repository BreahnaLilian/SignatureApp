using MediatR;
using SignatureApplication.Users.ViewModels;

namespace SignatureApplication.Auth.Query.Login
{
    public class LoginQuery : IRequest<DetailsUserViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
