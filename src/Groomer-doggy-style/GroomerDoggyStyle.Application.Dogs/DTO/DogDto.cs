using GroomerDoggyStyle.Domain.Enums;

namespace GroomerDoggyStyle.Application.Dogs.DTO;

public class DogDto
{
    public string? Name { get; set; }
    public int? Age { get; set; }
    public int? Weight { get; set; }
    public string? Breed { get; set; }
    public Sex Sex { get; set; } = Sex.Unknown;
    public int OwnerId { get; set; }
}

