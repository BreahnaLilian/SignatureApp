using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureApplication.Common;
using SignatureApplication.Users.ViewModels;
using SignatureDomain.Entities;

namespace SignatureApplication.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserViewModel>
    {
        private readonly ISignatureDbContext context;

        public UpdateUserCommandHandler(ISignatureDbContext context)
        {
            this.context = context;
        }

        async Task IRequestHandler<UpdateUserViewModel>.Handle(UpdateUserViewModel request, CancellationToken cancellationToken)
        {
            string email = request.Email.Trim().ToLower();

            User existingUser = await this.context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Trim() == email, cancellationToken);
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

            this.context.Entry(user).State = EntityState.Modified;
            await this.context.SaveChangesAsync(cancellationToken);
        }
    }
}
