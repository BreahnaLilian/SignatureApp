using AutoMapper;
using LinqToDB;
using MediatR;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureApplication.Users.ViewModels;
using SignatureCommon.Models.Exception;
using SignatureDomain.Entities;

namespace SignatureApplication.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserViewModel>
    {
        private readonly ISignatureDbContext _signatureDbContext;
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService, IMapper mapper)
        {
            _signatureDbContext = signatureDbContext;
            _cacheService = cacheService;
            _mapper = mapper;
        }

        async Task IRequestHandler<UpdateUserViewModel>.Handle(UpdateUserViewModel request, CancellationToken cancellationToken)
        {
            string email = request.Email.Trim().ToLower();
            
            User existingUser = await _signatureDbContext.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
            if (existingUser == null)
            {
                throw new UserNotExistException(email);
            }

            User user = _mapper.Map<User>(request);

            await _cacheService.RemoveDataAsync("users", cancellationToken);
            await _cacheService.RemoveDataAsync("user_" + request.Id, cancellationToken);

            await _signatureDbContext.UpdateAsync(user, cancellationToken);

            var expiryDate = DateTimeOffset.Now.AddSeconds(30);
            await _cacheService.SetDataAsync("user_" + request.Id, request, expiryDate, cancellationToken);
        }
    }
}
