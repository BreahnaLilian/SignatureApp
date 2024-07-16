using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureApplication.Organizations.ViewModels;
using SignatureDomain.Entities;
using System.Text;

namespace SignatureApplication.Organizations.Commands.CreateOrganization
{
    public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationViewModel>
    {
        private readonly ISignatureDbContext signatureDbContext;
        private readonly ICacheService cacheService;
        private readonly IMapper mapper;

        public CreateOrganizationCommandHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService, IMapper mapper)
        {
            this.signatureDbContext = signatureDbContext;
            this.cacheService = cacheService;
            this.mapper = mapper;
        }

        async Task IRequestHandler<CreateOrganizationViewModel>.Handle(CreateOrganizationViewModel request, CancellationToken cancellationToken)
        {
            Organization existingOrganization = await signatureDbContext.Organizations.FirstOrDefaultAsync(x => x.IDNO == request.IDNO, cancellationToken);
            if(existingOrganization != null)
            {
                throw new NotImplementedException();
            }

            Organization organization = mapper.Map<Organization>(request);

            //encoding to base64 for moment
            organization.ApiKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(ApiKeyGenerator.GenerateApiKey(64))).ToString();
            //decoding Encoding.UTF8.GetString(System.Convert.FromBase64String(ApiKey))
            organization.Status = SignatureCommon.Enums.OrganizationStatus.New;

            cacheService.RemoveData("organizations", cancellationToken);

            signatureDbContext.Entry(organization).State = EntityState.Added;
            await signatureDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
