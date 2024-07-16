using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Signature.WebAPI.Controllers
{
    //[ApiController]
    [Route("api/[controller]")]
    public class OrganizationsController : BaseController
    {
        private IMediator mediator;
        public OrganizationsController(IMediator mediator) : base(mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetOrganizations()
        {
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult DetailsOrganization()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult CreateOrganization()
        {
            return View();
        }
        
        [HttpPut]
        public IActionResult UpdateOrganization()
        {
            return View();
        }
        
        //[HttpDelete]
        //public IActionResult DeleteOrganization()
        //{
        //    return View();
        //}
        
    }
}
