using GroomerDoggyStyle.Application.Service;
using GroomerDoggyStyle.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GroomerDoggyStyle.Api.Controllers
{
    [Route("api/owners")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        public async Task<ActionResult> Create(Owner owner)
        {           
            await _ownerService.CreateOwnerAsync(owner);

            return Ok();
        }



    }
}
