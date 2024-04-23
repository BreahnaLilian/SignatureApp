using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureApplication.Common;
using SignatureApplication.Users.ViewModels;

namespace SignatureApplication.Users.Query.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, DetailsUserViewModel>
    {
        public readonly ISignatureDbContext signatureDbContext;

        public GetUserDetailsQueryHandler(ISignatureDbContext signatureDbContext)
        {
            this.signatureDbContext = signatureDbContext;
        }
        public async Task<DetailsUserViewModel> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {

            DetailsUserViewModel detailsUserViewModel = await signatureDbContext.Users
                .Where(x => x.Id == request.Id)
                .Select(x => new DetailsUserViewModel
                {
                    Address = x.Address,
                    DateOfBirth = x.DateOfBirth,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    Gender = x.Gender,
                    IDNP = x.IDNP,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Status = x.Status
                }).FirstOrDefaultAsync();

            return detailsUserViewModel;
        }
    }
}
