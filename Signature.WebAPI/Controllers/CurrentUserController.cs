using Microsoft.AspNetCore.Mvc;

namespace Signature.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrentUserController : BaseController
    {
        [HttpGet("CurrentUser")]
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

        [HttpPut("CurrentUser")]
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
