using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Signature.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrentUserController : BaseController
    {
        private IMediator mediator;
        public CurrentUserController(IMediator mediator) : base(mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentUser(Guid id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return CreateJsonException(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCurrentUser(FormCollection keyValuePairs)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return CreateJsonException(ex);
            }
        }
    }
}
