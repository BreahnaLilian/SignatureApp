using SignatureApplication.Common.Interfaces;
using SignatureApplication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SignatureApplication.Files.ViewModels;

namespace SignatureApplication.Files.Commands.CreateFile
{
    public class CreateFileCommandHandler : IRequestHandler<CreateFileViewModel>
    {
        private readonly ISignatureDbContext signatureDbContext;
        private readonly ICacheService cacheService;

        public CreateFileCommandHandler(ISignatureDbContext signatureDbContext, ICacheService cacheService)
        {
            this.signatureDbContext = signatureDbContext;
            this.cacheService = cacheService;
        }

        public Task Handle(CreateFileViewModel request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //async Task IRequestHandler<CreateFileViewModel>.Handle(IFile request, CancellationToken cancellationToken)
        //{


        //    throw new NotImplementedException();
        //}
    }
}
