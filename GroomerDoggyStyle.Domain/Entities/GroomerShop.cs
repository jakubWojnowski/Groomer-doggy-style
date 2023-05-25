namespace GroomerDoggyStyle.Domain.Entities;

public class GroomerShop
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }
    public int AddressId { get; set; }

    public Address Address { get; set; }
    public List<Visit> Visits { get; set; }
    public List<Offer> Offers { get; set; }
    public List<Employee> Employees { get; set; }
}