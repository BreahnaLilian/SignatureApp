using AutoMapper;
using LinqToDB;
using MediatR;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureDomain.Entities;

namespace SignatureApplication.Users.Query.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserVm>>
    {
        private readonly ISignatureDbContext _signatureDbContext;
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService, IMapper mapper)
        {
            _signatureDbContext = signatureDbContext;
            _cacheService = cacheService;
            _mapper = mapper;
        }

        public async Task<List<UserVm>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            List<UserVm> userList = await _cacheService.GetDataAsync<List<UserVm>>("users", cancellationToken);

            if (userList == null || userList.Count() <= 0)
            {
                List<User> userDb = await _signatureDbContext.Users.ToListAsync(cancellationToken);
                userList = _mapper.Map<List<UserVm>>(userDb);

                var expiryDate = DateTimeOffset.Now.AddSeconds(30);
                await _cacheService.SetDataAsync("users", userList, expiryDate, cancellationToken);
            }

            return userList;
        }
    }
}
