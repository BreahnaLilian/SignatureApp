using MediatR;
using Microsoft.AspNetCore.Mvc;
using SignatureApplication.Organizations.Query.GetOrganizationDetails;
using SignatureApplication.Organizations.Query.GetOrganizationList;
using SignatureApplication.Organizations.ViewModels;

namespace Signature.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrganizationsController : BaseController
{
    private readonly IMediator mediator;
    public OrganizationsController(IMediator mediator) : base(mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrganizations(CancellationToken cancellationToken)
    {
        try
        {
            List<OrganizationVm> organizationList = await mediator.Send(new GetOrganizationListQuery() { }, cancellationToken);
            return CreateJsonCollectionOk(organizationList);
        }
        catch (Exception ex)
        {
            return CreateJsonException(ex);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> DetailsOrganization(Guid id, CancellationToken cancellationToken)
    {
        if (id == Guid.Empty)
        {
            return CreateJsonError("Id must be valid");
        }

        try
        {
            DetailsOrganizationViewModel detailsOrganizationViewModel = await mediator.Send(new GetOrganizationDetailsQuery() { Id = id }, cancellationToken);

            return CreateJsonOk(detailsOrganizationViewModel);
        }
        catch (Exception ex)
        {
            return CreateJsonException(ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrganization(CreateOrganizationViewModel createOrganizationViewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return CreateJsonNotValid(ModelState, true);
        }

        try
        {
            await mediator.Send(createOrganizationViewModel, cancellationToken);
            return CreateJsonOk();
        }
        catch (Exception ex)
        {
            return CreateJsonException(ex);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrganization(UpdateOrganizationViewModel updateOrganizationViewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return CreateJsonNotValid(ModelState, true);
        }

        try
        {
            await mediator.Send(updateOrganizationViewModel, cancellationToken);
            return CreateJsonOk();
        }
        catch (Exception ex)
        {
            return CreateJsonException(ex);
        }
    }

    //[HttpDelete]
    //public IActionResult DeleteOrganization()
    //{
    //    try
    //    {

    //    }
    //    catch (Exception ex)
    //    {
    //        return CreateJsonException(ex);
    //    }
    //    return View();
    //}

}
