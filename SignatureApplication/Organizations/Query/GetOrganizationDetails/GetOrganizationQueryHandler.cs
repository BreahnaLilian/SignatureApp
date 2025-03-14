using AutoMapper;
using LinqToDB;
using MediatR;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureApplication.Organizations.ViewModels;
using SignatureDomain.Entities;

namespace SignatureApplication.Organizations.Query.GetOrganizationDetails
{
    public class GetOrganizationQueryHandler : IRequestHandler<GetOrganizationDetailsQuery, DetailsOrganizationViewModel>
    {
        private readonly ISignatureDbContext signatureDbContext;
        private readonly ICacheService cacheService;
        private readonly IMapper mapper;

        public GetOrganizationQueryHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService, IMapper mapper)
        {
            this.signatureDbContext = signatureDbContext;
            this.cacheService = cacheService;
            this.mapper = mapper;
        }

        public async Task<DetailsOrganizationViewModel> Handle(GetOrganizationDetailsQuery request, CancellationToken cancellationToken)
        {
            DetailsOrganizationViewModel detailsOrganizationViewModel = await cacheService.GetDataAsync<DetailsOrganizationViewModel>("organization_" + request.Id, cancellationToken);

            if (detailsOrganizationViewModel == null)
            {
                Organization organizationDb = await signatureDbContext.Organizations.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                detailsOrganizationViewModel = mapper.Map<DetailsOrganizationViewModel>(organizationDb);

                var expiriyDate = DateTimeOffset.Now.AddSeconds(30);
                await cacheService.SetDataAsync("organization_" + request.Id, detailsOrganizationViewModel, expiriyDate, cancellationToken);
            }

            return detailsOrganizationViewModel;
        }
    }
}
