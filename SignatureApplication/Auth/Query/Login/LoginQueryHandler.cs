using AutoMapper;
using LinqToDB;
using MediatR;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureApplication.Users.ViewModels;

namespace SignatureApplication.Auth.Query.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, DetailsUserViewModel>
    {
        private readonly ISignatureDbContext _signatureDbContext;
        private readonly IMapper _mapper;

        public LoginQueryHandler(ISignatureDbContext signatureDbContext, IMapper mapper)
        {
            _signatureDbContext = signatureDbContext;
            _mapper = mapper;
        }

        public async Task<DetailsUserViewModel> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var userDb = await _signatureDbContext.Users
                .LoadWith(x => x.Organization)
                .FirstOrDefaultAsync(x => x.Email == request.Email.ToLower().Trim() 
                                          && x.Password == Hash.GetHashSHA256(request.Password), cancellationToken);
            
            DetailsUserViewModel detailsUserViewModel = _mapper.Map<DetailsUserViewModel>(userDb);

            return detailsUserViewModel;
        }
    }
}
