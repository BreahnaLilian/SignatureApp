using MediatR;
using Microsoft.AspNetCore.Mvc;
using SignatureApplication.Users.Query.GetUserDetails;
using SignatureApplication.Users.Query.GetUserList;
using SignatureApplication.Users.ViewModels;

namespace Signature.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : BaseController
{
    private readonly IMediator mediator;
    public UsersController(IMediator mediator) : base(mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        try
        {
            List<UserVm> usersListViewModel = await mediator.Send(new GetUserListQuery() { }, cancellationToken);
            return CreateJsonCollectionOk(usersListViewModel);
        }
        catch (Exception ex)
        {
            return CreateJsonException(ex);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> DetailsUser(Guid id, CancellationToken cancellationToken)
    {
        if(id == Guid.Empty)
        {
            return CreateJsonError("Id must be valid");
        }

        try
        {
            DetailsUserViewModel detailsUserViewModel = await mediator.Send(new GetUserDetailsQuery() { Id = id }, cancellationToken);
            return CreateJsonOk(detailsUserViewModel);
        }
        catch (Exception ex)
        {
            return CreateJsonException(ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserViewModel createUserViewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return CreateJsonNotValid(ModelState, true);
        }

        try
        {
            await mediator.Send(createUserViewModel, cancellationToken);
            return CreateJsonOk();
        }
        catch (Exception ex)
        {
            return CreateJsonException(ex);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateUserViewModel updateUserViewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return CreateJsonNotValid(ModelState, true);
        }

        try
        {
            await mediator.Send(updateUserViewModel, cancellationToken);
            return CreateJsonOk();
        }
        catch (Exception ex)
        {
            return CreateJsonException(ex);
        }
    }

    //[HttpDelete]
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
