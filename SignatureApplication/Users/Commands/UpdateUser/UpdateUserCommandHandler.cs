using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureApplication.Users.ViewModels;
using SignatureDomain.Entities;

namespace SignatureApplication.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserViewModel>
    {
        private readonly ISignatureDbContext signatureDbContext;
        private readonly ICacheService cacheService;
        private readonly IMapper mapper;

        public UpdateUserCommandHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService, IMapper mapper)
        {
            this.signatureDbContext = signatureDbContext;
            this.cacheService = cacheService;
            this.mapper = mapper;
        }

        async Task IRequestHandler<UpdateUserViewModel>.Handle(UpdateUserViewModel request, CancellationToken cancellationToken)
        {
            string email = request.Email.Trim().ToLower();

            User existingUser = await signatureDbContext.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Trim() == email, cancellationToken);
            if (existingUser == null)
            {
                throw new NotImplementedException();
            }

            User user = mapper.Map<User>(request);

            cacheService.RemoveData("users", cancellationToken);
            cacheService.RemoveData("user_" + request.Id, cancellationToken);

            signatureDbContext.Entry(user).State = EntityState.Modified;
            await signatureDbContext.SaveChangesAsync(cancellationToken);

            var expiryDate = DateTimeOffset.Now.AddSeconds(30);
            cacheService.SetData("user_" + request.Id, request, expiryDate, cancellationToken);
        }
    }
}
