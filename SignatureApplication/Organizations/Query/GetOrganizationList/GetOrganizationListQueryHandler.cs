using AutoMapper;
using LinqToDB;
using MediatR;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureDomain.Entities;

namespace SignatureApplication.Organizations.Query.GetOrganizationList
{
    public class GetOrganizationListQueryHandler : IRequestHandler<GetOrganizationListQuery, List<OrganizationVm>>
    {
        private readonly ISignatureDbContext _signatureDbContext;
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;

        public GetOrganizationListQueryHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService, IMapper mapper)
        {
            _signatureDbContext = signatureDbContext;
            _cacheService = cacheService;
            _mapper = mapper;
        }

        public async Task<List<OrganizationVm>> Handle(GetOrganizationListQuery request, CancellationToken cancellationToken)
        {
            List<OrganizationVm> organizationList = await _cacheService.GetDataAsync<List<OrganizationVm>>("organizations", cancellationToken);

            if(organizationList == null || organizationList.Count == 0)
            {
                List<Organization> organizationsDb = await _signatureDbContext.Organizations.ToListAsync(cancellationToken);
                organizationList = _mapper.Map<List<OrganizationVm>>(organizationsDb);

                var expiryDate = DateTimeOffset.Now.AddSeconds(30);
                await _cacheService.SetDataAsync("organizations", organizationList, expiryDate, cancellationToken);
            }

            return organizationList;
        }
    }
}
