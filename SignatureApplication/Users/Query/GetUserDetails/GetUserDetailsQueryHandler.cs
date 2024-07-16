using AutoMapper;
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
        private readonly IMapper mapper;

        public GetUserDetailsQueryHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService, IMapper mapper)
        {
            this.signatureDbContext = signatureDbContext;
            this.cacheService = cacheService;
            this.mapper = mapper;
        }
        public async Task<DetailsUserViewModel> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {

            DetailsUserViewModel detailsUserViewModel = cacheService.GetData<DetailsUserViewModel>("user_" + request.Id, cancellationToken);

            if (detailsUserViewModel == null)
            {
                detailsUserViewModel = mapper.Map<DetailsUserViewModel>(await signatureDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken));

                var expiryDate = DateTimeOffset.Now.AddSeconds(30);
                cacheService.SetData("user_" + request.Id, detailsUserViewModel, expiryDate, cancellationToken);
            }
            return detailsUserViewModel;
        }
    }
}
