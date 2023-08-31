namespace GroomerDoggyStyle.Application.Visits.DTO;

public class VisitDto
{
    public DateTime DateOfVisit { get; set; }
    public int DurationInMinutes { get; set; }
    public decimal Price { get; set; }
    public int GroomerShopId { get; set; }
    public int DogId { get; set; }
}