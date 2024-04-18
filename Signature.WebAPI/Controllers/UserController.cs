using Microsoft.AspNetCore.Mvc;
using SignatureApplication.Users.ViewModels;

namespace Signature.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        [HttpGet("Users")]
        public async Task<IActionResult> GetUsers()
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
        public async Task<IActionResult> GetUser(Guid id)
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
        public async Task<IActionResult> CreateUser(CreateUserViewModel createUserViewModel)
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

        [HttpPut("User")]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel updateUserViewModel)
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

        [HttpDelete("User")]
        public async Task<IActionResult> DeleteUser(Guid id)
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
