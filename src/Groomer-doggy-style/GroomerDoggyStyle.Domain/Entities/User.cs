namespace GroomerDoggyStyle.Domain.Entities;

public abstract class User
{
    public int Id { get; set; }
    public string? Mail { get; set; }
    public string? PhoneNumber { get; set; }
    public string? HashedPassword { get; set; }
}