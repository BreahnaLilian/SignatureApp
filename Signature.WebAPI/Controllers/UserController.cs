using Microsoft.AspNetCore.Mvc;
using SignatureApplication.Users.Query.GetUserDetails;
using SignatureApplication.Users.Query.GetUserList;
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
                UsersViewModel usersListViewModel = await Mediator.Send(new GetUserListQuery() { }, cancellationToken);
                return CreateJsonOk(usersListViewModel);
            }
            catch (Exception ex)
            {
                return CreateJsonException(ex);
            }
        }

        [HttpGet("User")]
        public async Task<IActionResult> DetailsUser(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                DetailsUserViewModel detailsUserViewModel = await Mediator.Send(new GetUserDetailsQuery() { Id = id }, cancellationToken);
                return CreateJsonOk(detailsUserViewModel);
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

        //[HttpDelete("User")]
        //public async Task<IActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        throw new NotImplementedException();
        //    }
        //    catch (Exception ex)
        //    {
        //        return CreateJsonException(ex);
        //    }
        //}
    }
}
