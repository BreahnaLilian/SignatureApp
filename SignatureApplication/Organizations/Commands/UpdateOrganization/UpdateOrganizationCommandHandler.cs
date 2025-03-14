using AutoMapper;
using LinqToDB;
using LinqToDB.Reflection;
using MediatR;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureApplication.Organizations.ViewModels;
using SignatureDomain.Entities;

namespace SignatureApplication.Organizations.Commands.UpdateOrganization
{
    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationViewModel>
    {
        private readonly ISignatureDbContext _signatureDbContext;
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;

        public UpdateOrganizationCommandHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService, IMapper mapper)
        {
            _signatureDbContext = signatureDbContext;
            _cacheService = cacheService;
            _mapper = mapper;
        }

        async Task IRequestHandler<UpdateOrganizationViewModel>.Handle(UpdateOrganizationViewModel request, CancellationToken cancellationToken)
        {
            string idno = request.IDNO;

            Organization existingOrganization = await _signatureDbContext.Organizations.FirstOrDefaultAsync(x => x.IDNO == idno, cancellationToken);

            if (existingOrganization != null)
            {
                throw new NotImplementedException();
            }

            Organization organization = _mapper.Map<Organization>(request);

            await _cacheService.RemoveDataAsync("organizations", cancellationToken);
            await _cacheService.RemoveDataAsync("organization_" + request.Id, cancellationToken);

            await _signatureDbContext.UpdateAsync(organization, cancellationToken);

            var expiryDate = DateTimeOffset.Now.AddSeconds(30);
            await _cacheService.SetDataAsync("organization_" + request.Id, request, expiryDate, cancellationToken);
        }
    }
}
