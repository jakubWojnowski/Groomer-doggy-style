using GroomerDoggyStyle.Domain.Enums;

namespace GroomerDoggyStyle.Domain.Entities;

public class Offer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int DurationTimeInMinutes { get; set; }
    public decimal Price { get; set; }
    public WeightType WeightType { get; set; }

    public List<GroomerShop>? GroomerShops { get; set; }
}