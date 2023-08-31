using GroomerDoggyStyle.Domain.Enums;

namespace GroomerDoggyStyle.Domain.Entities;

public class Employee : User
{
    
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public int GroomerShopId { get; set; }
    
    public GroomerShop? GroomerShop { get; set; }
    public PositionType PositionType { get; set; }

 

}