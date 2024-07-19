using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignatureApplication.Auth.Query.Login;
using SignatureApplication.Auth.ViewModels;

namespace Signature.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator) : base(mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthViewModel authViewModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return CreateJsonNotValid(ModelState, true);
            }

            var user = await mediator.Send(new LoginQuery() { Email = authViewModel.Email, Password = authViewModel.Password }, cancellationToken);

            if(user == null)
            {
                return CreateJsonError("Email or password is wrong!");
            }

            return CreateJsonOk(user);
        }


    }
}
