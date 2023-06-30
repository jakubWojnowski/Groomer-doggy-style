using GroomerDoggyStyle.Domain.Enums;

namespace GroomerDoggyStyle.Domain.Entities;

public class Dog
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public int Weight { get; set; }
    public string? Breed { get; set; }
    public Sex Sex { get; set; }
    public int OwnerId { get; set; }

    public List<Visit>? Visits { get; set; }
    public Owner? Owner { get; set; }


}