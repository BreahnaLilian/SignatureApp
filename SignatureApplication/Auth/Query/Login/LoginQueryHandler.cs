using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureApplication.Users.ViewModels;

namespace SignatureApplication.Auth.Query.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, DetailsUserViewModel>
    {
        private readonly ISignatureDbContext signatureDbContext;
        private readonly ICacheService cacheService;
        private readonly IMapper mapper;

        public LoginQueryHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService, IMapper mapper)
        {
            this.signatureDbContext = signatureDbContext;
            this.cacheService = cacheService;
            this.mapper = mapper;
        }

        public async Task<DetailsUserViewModel> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

            var userDb = await signatureDbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email.ToLower().Trim() || x.Password == request.Password);

            DetailsUserViewModel detailsUserViewModel = mapper.Map<DetailsUserViewModel>(userDb);

            return detailsUserViewModel;
        }
    }
}
