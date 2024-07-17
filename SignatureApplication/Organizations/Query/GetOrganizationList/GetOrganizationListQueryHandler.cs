using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureDomain.Entities;

namespace SignatureApplication.Organizations.Query.GetOrganizationList
{
    public class GetOrganizationListQueryHandler : IRequestHandler<GetOrganizationListQuery, List<OrganizationVm>>
    {
        private readonly ISignatureDbContext signatureDbContext;
        private readonly ICacheService cacheService;
        private readonly IMapper mapper;

        public GetOrganizationListQueryHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService, IMapper mapper)
        {
            this.signatureDbContext = signatureDbContext;
            this.cacheService = cacheService;
            this.mapper = mapper;
        }

        public async Task<List<OrganizationVm>> Handle(GetOrganizationListQuery request, CancellationToken cancellationToken)
        {
            List<OrganizationVm> organizationList = cacheService.GetData<List<OrganizationVm>>("organizations", cancellationToken);

            if(organizationList == null || organizationList.Count == 0)
            {
                List<Organization> organizationsDb = await signatureDbContext.Organizations.ToListAsync(cancellationToken);

                organizationList = mapper.Map<List<OrganizationVm>>(organizationsDb);

                var expiryDate = DateTimeOffset.Now.AddSeconds(30);
                cacheService.SetData("organizations", organizationList, expiryDate, cancellationToken);
            }

            return organizationList;
        }
    }
}
