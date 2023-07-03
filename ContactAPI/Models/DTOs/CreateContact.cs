using ContactAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace ContactAPI.Models.DTOs
{
    public class CreateContact
    {
        [Required]
        public string Name { get; set; }
        public int? CelularNumber { get; set; }
        public int? TelephoneNumber { get; set; }
        public string Description = string.Empty;
        public User? User;
    }
}

