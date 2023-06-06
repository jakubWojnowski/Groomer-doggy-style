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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerDto>>> GetAll()
        {
            var owners = await _ownerService.GetAllOwnersAsync();

            return Ok(owners);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<OwnerDto>>> Get([FromRoute] int id)
        {
            var owner = await _ownerService.GetOwnerByIdAsync(id);

            return Ok(owner);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] OwnerDto ownerDto)
        {
            var id = await _ownerService.CreateOwnerAsync(ownerDto);

            return Created($"api/owners/{id}", null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] OwnerDto ownerDto)
        {
            await _ownerService.UpdateOwnerAsync(id, ownerDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _ownerService.DeleteOwnerAsync(id);

            return NoContent();
        }


    }
}
