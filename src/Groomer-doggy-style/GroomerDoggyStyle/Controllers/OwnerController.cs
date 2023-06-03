using GroomerDoggyStyle.Application.DTO;
using GroomerDoggyStyle.Application.Service;
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
        public async Task<ActionResult> Create([FromBody] OwnerDto ownerDto)
        {           
            var id = await _ownerService.CreateOwnerAsync(ownerDto);

            return Created($"api/owners/{id}", null);
        }
    }
}
