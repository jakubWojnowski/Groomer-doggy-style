namespace GroomerDoggyStyle.Domain.Entities;

public class Address
{
    public int Id { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? BuildingNumber { get; set; }
    public string? PostalCode { get; set; }
    public int? GroomerShopId { get; set; }

    public GroomerShop? GroomerShop { get; set; }
}