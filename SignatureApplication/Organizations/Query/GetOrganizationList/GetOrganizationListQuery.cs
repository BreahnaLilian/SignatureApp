using MediatR;
using SignatureApplication.Organizations.ViewModels;

namespace SignatureApplication.Organizations.Query.GetOrganizationList
{
    public class GetOrganizationListQuery : IRequest<List<OrganizationVm>>
    {
    }
}
