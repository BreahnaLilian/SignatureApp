using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureApplication.Users.ViewModels;

namespace SignatureApplication.Users.Query.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UsersViewModel>
    {
        private readonly ISignatureDbContext signatureDbContext;
        private readonly ICacheService cacheService;
        public GetUserListQueryHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService)
        {
            this.signatureDbContext = signatureDbContext;
            this.cacheService = cacheService;
        }
        public async Task<UsersViewModel> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {

            List<UserVm> userList = new List<UserVm>();
            userList = cacheService.GetData<List<UserVm>>("users");

            if(userList == null && userList.Count() <= 0)
            {
                userList = await signatureDbContext.Users
                    .Select(x => new UserVm
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        Status = x.Status,
                    }).ToListAsync();
                var expiryDate = DateTimeOffset.Now.AddSeconds(30);
                cacheService.SetData("users", userList, expiryDate);
            }

            var usersViewModel = new UsersViewModel()
            {
                Users = userList
            };

            return usersViewModel;
        }
    }
}
