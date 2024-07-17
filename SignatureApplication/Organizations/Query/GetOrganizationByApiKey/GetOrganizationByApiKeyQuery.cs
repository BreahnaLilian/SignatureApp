using MediatR;
using SignatureApplication.Organizations.ViewModels;

namespace SignatureApplication.Organizations.Query.GetOrganizationByApiKey;

public class GetOrganizationByApiKeyQuery : IRequest<DetailsOrganizationViewModel>
{
    public string ApiKey { get; set; }
}
