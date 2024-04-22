using Microsoft.AspNetCore.Mvc;
using SignatureApplication.Users.ViewModels;

namespace Signature.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {

        [HttpGet("Users")]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return CreateJsonException(ex);
            }
        }

        [HttpGet("User")]
        public async Task<IActionResult> GetUser(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return CreateJsonException(ex);
            }
        }

        [HttpPost("User")]
        public async Task<IActionResult> CreateUser(CreateUserViewModel createUserViewModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return CreateJsonError("Input is not valid");
            }

            try
            {
                await Mediator.Send(createUserViewModel, cancellationToken);
                return CreateJsonOk();
            }
            catch (Exception ex)
            {
                return CreateJsonException(ex);
            }
        }

        [HttpPut("User")]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel updateUserViewModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return CreateJsonError("Input is not valid");
            }

            try
            {
                await Mediator.Send(updateUserViewModel, cancellationToken);
                return CreateJsonOk();
            }
            catch (Exception ex)
            {
                return CreateJsonException(ex);
            }
        }

        [HttpDelete("User")]
        public async Task<IActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return CreateJsonException(ex);
            }
        }
    }
}
