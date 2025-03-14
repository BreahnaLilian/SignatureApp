using AutoMapper;
using LinqToDB;
using MediatR;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureApplication.Users.ViewModels;
using SignatureCommon.Models.Exception;
using SignatureDomain.Entities;

namespace SignatureApplication.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserViewModel>
    {
        private readonly ISignatureDbContext _signatureDbContext;
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService, IMapper mapper)
        {
            _signatureDbContext = signatureDbContext;
            _cacheService = cacheService;
            _mapper = mapper;
        }

        async Task IRequestHandler<CreateUserViewModel>.Handle(CreateUserViewModel request, CancellationToken cancellationToken)
        {
            string email = request.Email.Trim().ToLower();

            User existingUser = await _signatureDbContext.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Trim() == email, cancellationToken);
            if (existingUser != null)
            {
                throw new UserAlreadyExistException(existingUser.Email);
            }

            User user = _mapper.Map<User>(request);

            user.Password = Hash.GetHashSHA256(ApiKeyGenerator.GeneratePassword(12));
            user.Status = SignatureCommon.Enums.UserStatus.New;

            await _cacheService.RemoveDataAsync("users", cancellationToken);

            await _signatureDbContext.InsertAsync(user, cancellationToken);

            //TODO: Add event that will send email with password to user

        }
    }
}
