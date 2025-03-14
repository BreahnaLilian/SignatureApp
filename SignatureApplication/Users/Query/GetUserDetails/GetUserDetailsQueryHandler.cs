using AutoMapper;
using LinqToDB;
using MediatR;
using SignatureApplication.Common;
using SignatureApplication.Common.Interfaces;
using SignatureApplication.Users.ViewModels;

namespace SignatureApplication.Users.Query.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, DetailsUserViewModel>
    {
        private readonly ISignatureDbContext _signatureDbContext;
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService, IMapper mapper)
        {
            _signatureDbContext = signatureDbContext;
            _cacheService = cacheService;
            _mapper = mapper;
        }
        public async Task<DetailsUserViewModel> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            DetailsUserViewModel detailsUserViewModel = await _cacheService.GetDataAsync<DetailsUserViewModel>("user_" + request.Id, cancellationToken);

            if (detailsUserViewModel == null)
            {
                detailsUserViewModel = _mapper.Map<DetailsUserViewModel>(await _signatureDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken));

                var expiryDate = DateTimeOffset.Now.AddSeconds(30);
                await _cacheService.SetDataAsync("user_" + request.Id, detailsUserViewModel, expiryDate, cancellationToken);
            }
            return detailsUserViewModel;
        }
    }
}
