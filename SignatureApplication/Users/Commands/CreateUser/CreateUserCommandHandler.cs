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
        public CreateUserCommandHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService)
        {
            this.signatureDbContext = signatureDbContext;
            this.cacheService = cacheService;
        }

        async Task IRequestHandler<CreateUserViewModel>.Handle(CreateUserViewModel request, CancellationToken cancellationToken)
        {
            string email = request.Email.Trim().ToLower();

            User existingUser = await signatureDbContext.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Trim() == email, cancellationToken);
            if (existingUser != null)
            {
                throw new NotImplementedException();
            }

            User user = new User()
            {
                Email = email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                CreateDate = DateTime.Now,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                IDNP = request.IDNP,
                LastModified = DateTime.Now,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                Status = SignatureCommon.Enums.UserStatus.Inactive,
            };

            cacheService.RemoveData("users", cancellationToken);

            signatureDbContext.Entry(user).State = EntityState.Added;
            await signatureDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
