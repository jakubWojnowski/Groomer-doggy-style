namespace GroomerDoggyStyle.Application.Employee.DTO;

public record RegisterEmployeeDto
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string PhoneNumber { get; set; }
    public int GroomerShopId { get; set; }
    
    //here I want to add feature to update properties of employee. 
    // I want to use this dto to update employee by adding mehod to hash password which will be
    // saved inside new property called HashedPassword.
    //basically property will be set by hashing password property.
    //than it will be used in mapper to save it in database.
}