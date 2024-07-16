using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureApplication.Organizations.ViewModels;
using SignatureDomain.Entities;

namespace SignatureApplication.Organizations.Commands.UpdateOrganization
{
    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationViewModel>
    {
        private readonly ISignatureDbContext signatureDbContext;
        private readonly ICacheService cacheService;
        private readonly IMapper mapper;

        public UpdateOrganizationCommandHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService, IMapper mapper)
        {
            this.signatureDbContext = signatureDbContext;
            this.cacheService = cacheService;
            this.mapper = mapper;
        }

        async Task IRequestHandler<UpdateOrganizationViewModel>.Handle(UpdateOrganizationViewModel request, CancellationToken cancellationToken)
        {
            string idno = request.IDNO;

            Organization existingOrganization = await signatureDbContext.Organizations.FirstOrDefaultAsync(x => x.IDNO == idno);

            if (existingOrganization == null)
            {
                throw new NotImplementedException();
            }

            Organization organization = mapper.Map<Organization>(request);

            cacheService.RemoveData("organizations", cancellationToken);
            cacheService.RemoveData("organization_" + request.Id, cancellationToken);

            signatureDbContext.Entry(organization).State = EntityState.Modified;
            await signatureDbContext.SaveChangesAsync(cancellationToken);

            var expiryDate = DateTimeOffset.Now.AddSeconds(30);
            cacheService.SetData("organization_" + request.Id, request, expiryDate, cancellationToken);
        }
    }
}
