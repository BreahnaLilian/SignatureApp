using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureApplication.Common;
using SignatureApplication.Users.ViewModels;

namespace SignatureApplication.Users.Query.GetUserUpdate
{
    public class GetUserUpdateQueryHandler : IRequestHandler<GetUserUpdateQuery, UpdateUserViewModel>
    {
        private readonly ISignatureDbContext signatureDbContext;

        public GetUserUpdateQueryHandler(ISignatureDbContext signatureDbContext)
        {
            this.signatureDbContext = signatureDbContext;
        }

        public async Task<UpdateUserViewModel> Handle(GetUserUpdateQuery request, CancellationToken cancellationToken)
        {
            UpdateUserViewModel updateUserViewModel = await signatureDbContext.Users
                .Where(x => x.Id == request.Id)
                .Select(x => new UpdateUserViewModel()
                {
                    Id = request.Id,
                    Address = x.Address,
                    DateOfBirth = x.DateOfBirth,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    Gender = x.Gender,
                    IDNP = x.IDNP,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Status = x.Status,
                }).FirstOrDefaultAsync();

            return updateUserViewModel;
        }
    }
}
