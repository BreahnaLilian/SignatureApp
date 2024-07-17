using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureDomain.Entities;

namespace SignatureApplication.Users.Query.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserVm>>
    {
        private readonly ISignatureDbContext signatureDbContext;
        private readonly ICacheService cacheService;
        private readonly IMapper mapper;

        public GetUserListQueryHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService, IMapper mapper)
        {
            this.signatureDbContext = signatureDbContext;
            this.cacheService = cacheService;
            this.mapper = mapper;
        }

        public async Task<List<UserVm>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            List<UserVm> userList = cacheService.GetData<List<UserVm>>("users", cancellationToken);

            if (userList == null || userList.Count() <= 0)
            {
                List<User> userDb = await signatureDbContext.Users.ToListAsync(cancellationToken);

                userList = mapper.Map<List<UserVm>>(userDb);

                var expiryDate = DateTimeOffset.Now.AddSeconds(30);
                cacheService.SetData("users", userList, expiryDate, cancellationToken);
            }

            return userList;
        }
    }
}
