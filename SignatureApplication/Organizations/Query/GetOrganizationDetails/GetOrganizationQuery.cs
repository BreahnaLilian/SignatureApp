using MediatR;
using SignatureApplication.Organizations.ViewModels;

namespace SignatureApplication.Organizations.Query.GetOrganizationDetails
{
    public class GetOrganizationQuery : IRequest<DetailsOrganizationViewModel>
    {
        public Guid Id { get; set; }
    }
}
