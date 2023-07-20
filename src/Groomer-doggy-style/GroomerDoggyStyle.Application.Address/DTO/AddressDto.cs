using System.ComponentModel.DataAnnotations;

namespace GroomerDoggyStyle.Application.Address.DTO;

public class AddressDto
{
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? BuildingNumber { get; set; }
        public string? PostalCode { get; set; }
        
 
     
        public int ShopId { get; set; }
}