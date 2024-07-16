using AutoMapper;
using MediatR;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureApplication.Organizations.ViewModels;

namespace SignatureApplication.Organizations.Query.GetOrganizationDetails
{
    public class GetOrganizationQueryHandler : IRequestHandler<GetOrganizationQuery, DetailsOrganizationViewModel>
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

        public async Task<DetailsOrganizationViewModel> Handle(GetOrganizationQuery request, CancellationToken cancellationToken)
        {
            DetailsOrganizationViewModel detailsOrganizationViewModel = cacheService.GetData<DetailsOrganizationViewModel>("organization_" + request.Id, cancellationToken);

            if (detailsOrganizationViewModel == null)
            {
                detailsOrganizationViewModel = mapper.Map<DetailsOrganizationViewModel>(await signatureDbContext.Organizations.FirstOrDefault(x => x.Id == request.Id, , cancellationToken);

                var expiriyDate = DateTimeOffset.Now.AddSeconds(30);
                cacheService.SetData("organization_" + request.Id, detailsOrganizationViewModel, expiriyDate, cancellationToken);
            }

            return detailsOrganizationViewModel;
        }
    }
}
