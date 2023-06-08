using GroomerDoggyStyle.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroomerDoggyStyle.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        public ActionResult<Dog> GetAllDogs()
        {
            var dog = new Dog()
            {
                Id = 1,
                Name = "Test",
                Age = 1,
                Weight = 1,
                Breed = "Text",
                Sex = Sex.Female,
                OwnerId = 1
            };


            return Ok(dog);
    }
}
}
