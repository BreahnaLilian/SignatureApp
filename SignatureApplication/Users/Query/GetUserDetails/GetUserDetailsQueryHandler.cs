using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureApplication.Users.ViewModels;

namespace SignatureApplication.Users.Query.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, DetailsUserViewModel>
    {
        private readonly ISignatureDbContext signatureDbContext;
        private readonly ICacheService cacheService;


        public GetUserDetailsQueryHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService)
        {
            this.signatureDbContext = signatureDbContext;
            this.cacheService = cacheService;
        }
        public async Task<DetailsUserViewModel> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {

            DetailsUserViewModel detailsUserViewModel = cacheService.GetData<DetailsUserViewModel>("user_" + request.Id, cancellationToken);

            if (detailsUserViewModel == null)
            {
                detailsUserViewModel = await signatureDbContext.Users
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

                var expiryDate = DateTimeOffset.Now.AddSeconds(30);
                cacheService.SetData("user_" + request.Id, detailsUserViewModel, expiryDate, cancellationToken);
            }
            return detailsUserViewModel;
        }
    }
}
