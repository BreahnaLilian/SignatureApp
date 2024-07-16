using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Signature.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : BaseController
    {
        private IMediator mediator;
        public FileController(IMediator mediator) : base(mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("Files")]
        public async Task<IActionResult> GetFiles()
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

        [HttpGet("File")]
        public async Task<IActionResult> GetFile(Guid id)
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

        [HttpPost("File")]
        public async Task<IActionResult> CreateFile(IFormFile formFile)
        {
            try
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return CreateJsonException(ex);
            }
        }

        [HttpPut("File")]
        public async Task<IActionResult> UpdateFile(IFormFileCollection formFiles)
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

        [HttpDelete("File")]
        public async Task<IActionResult> DeleteFile(Guid id)
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
