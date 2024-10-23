using System.ComponentModel.DataAnnotations;

namespace Motoland.Models
{
    public class CarAd
    {
        public int Id { get; set; }

        [Required]
        public string? Make { get; set; }

        [Required]
        public string? Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? Description { get; set; }

        
    }
}
