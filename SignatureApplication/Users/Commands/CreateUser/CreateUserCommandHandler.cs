using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureApplication.Users.ViewModels;
using SignatureDomain.Entities;

namespace SignatureApplication.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserViewModel>
    {
        private readonly ISignatureDbContext signatureDbContext;
        private readonly ICacheService cacheService;
        private readonly IMapper mapper;

        public CreateUserCommandHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService, IMapper mapper)
        {
            this.signatureDbContext = signatureDbContext;
            this.cacheService = cacheService;
            this.mapper = mapper;
        }

        async Task IRequestHandler<CreateUserViewModel>.Handle(CreateUserViewModel request, CancellationToken cancellationToken)
        {
            string email = request.Email.Trim().ToLower();

            User existingUser = await signatureDbContext.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Trim() == email, cancellationToken);
            if (existingUser != null)
            {
                throw new NotImplementedException();
            }

            User user = mapper.Map<User>(request);

            user.Password = Hash.GetHashSHA256(ApiKeyGenerator.GeneratePassword(12));
            user.Status = SignatureCommon.Enums.UserStatus.New;

            cacheService.RemoveData("users", cancellationToken);

            signatureDbContext.Entry(user).State = EntityState.Added;
            await signatureDbContext.SaveChangesAsync(cancellationToken);

            //TODO: Add event that will send email with password to user

        }
    }
}
