using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Signature.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilesController : BaseController
{
    private IMediator mediator;
    public FilesController(IMediator mediator) : base(mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
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

    [HttpGet("{id}")]
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

    [HttpPost]
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

    [HttpPut]
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

    [HttpDelete]
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
