using MediatR;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureApplication.Users.ViewModels;

namespace SignatureApplication.Users.Query.GetUserUpdate
{
    public class GetUserUpdateQueryHandler : IRequestHandler<GetUserUpdateQuery, UpdateUserViewModel>
    {
        private readonly ISignatureDbContext signatureDbContext;
        private readonly ICacheService cacheService;

        public GetUserUpdateQueryHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService)
        {
            this.signatureDbContext = signatureDbContext;
            this.cacheService = cacheService;
        }

        public async Task<UpdateUserViewModel> Handle(GetUserUpdateQuery request, CancellationToken cancellationToken)
        {

            UpdateUserViewModel updateUserViewModel = await cacheService.GetDataAsync<UpdateUserViewModel>("user_" + request.Id, cancellationToken);

            if(updateUserViewModel == null)
            {
                // updateUserViewModel = await signatureDbContext.Users
                // .Where(x => x.Id == request.Id)
                // .Select(x => new UpdateUserViewModel()
                // {
                //     Id = request.Id,
                //     Address = x.Address,
                //     DateOfBirth = x.DateOfBirth,
                //     Email = x.Email,
                //     FirstName = x.FirstName,
                //     Gender = x.Gender,
                //     IDNP = x.IDNP,
                //     LastName = x.LastName,
                //     PhoneNumber = x.PhoneNumber,
                //     Status = x.Status,
                // }).FirstOrDefaultAsync();
                
                updateUserViewModel = null;

                var expiryDate = DateTimeOffset.Now.AddSeconds(30);
                await cacheService.SetDataAsync("user_" + request.Id, updateUserViewModel, expiryDate, cancellationToken);
            }

            return updateUserViewModel;
        }
    }
}
