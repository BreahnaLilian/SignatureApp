using System.Text;
using AutoMapper;
using MediatR;
using SignatureApplication.Common;
using SignatureApplication.Organizations.ViewModels;
using SignatureDomain.Entities;

namespace SignatureApplication.Organizations.Query.GetOrganizationByApiKey
{
    public class GetOrganizationByApiKeyQueryHandler : IRequestHandler<GetOrganizationByApiKeyQuery, DetailsOrganizationViewModel>
    {
        private readonly ISignatureDbContext signatureDbContext;
        private readonly IMapper mapper;

        public GetOrganizationByApiKeyQueryHandler(ISignatureDbContext signatureDbContext, IMapper mapper)
        {
            this.signatureDbContext = signatureDbContext;
            this.mapper = mapper;
        }

        public async Task<DetailsOrganizationViewModel> Handle(GetOrganizationByApiKeyQuery request, CancellationToken cancellationToken)
        {
            var encodedAPiKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(request.ApiKey)).ToString();

            // var organizationDb = await signatureDbContext.Organizations.FirstOrDefaultAsync(x => x.ApiKey == encodedAPiKey, cancellationToken);
            List<Organization> organizationDb = null;

            DetailsOrganizationViewModel detailsOrganizationViewModel = mapper.Map<DetailsOrganizationViewModel>(organizationDb);

            return detailsOrganizationViewModel;
        }
    }
}
