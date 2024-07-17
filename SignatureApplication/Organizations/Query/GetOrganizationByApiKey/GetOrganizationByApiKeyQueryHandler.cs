using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureApplication.Common;
using SignatureApplication.Organizations.ViewModels;
using System.Text;

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

            var organizationDb = await signatureDbContext.Organizations.FirstOrDefaultAsync(x => x.ApiKey == encodedAPiKey, cancellationToken);

            DetailsOrganizationViewModel detailsOrganizationViewModel = mapper.Map<DetailsOrganizationViewModel>(organizationDb);

            return detailsOrganizationViewModel;
        }
    }
}
