namespace GroomerDoggyStyle.Domain.Entities;

public class Visit
{
    public int Id { get; set; }
    public DateTime DateOfVisit { get; set; }
    public int DurationInMinutes { get; set; }
    public int GroomerShopId { get; set; }
    public int DogId { get; set; }
    
    public GroomerShop GroomerShop { get; set; }
    public Dog Dog { get; set; }
}