namespace GroomerDoggyStyle.Domain.Entities;

public class Owner
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }

    public List<Dog> Dogs { get; set; }
}