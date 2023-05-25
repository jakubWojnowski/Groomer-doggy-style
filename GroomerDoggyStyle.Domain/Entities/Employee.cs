namespace GroomerDoggyStyle.Domain.Entities;
public enum PositionType
{
        Manager,
        Employee
}
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string PhoneNumber { get; set; }
    public int GroomerShopId { get; set; }
    
    public GroomerShop GroomerShop { get; set; }
    public PositionType PositionType { get; set; }

 

}