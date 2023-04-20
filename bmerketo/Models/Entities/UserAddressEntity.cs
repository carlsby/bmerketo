using System.ComponentModel.DataAnnotations;

namespace bmerketo.Models.Entities
{
    public class UserAddressEntity
    {
        [Key]
        public int Id { get; set; }
        public string? StreetName { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
    }
}
