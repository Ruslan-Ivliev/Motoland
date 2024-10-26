using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

       
        public string? ImagePaths { get; set; } // Для хранения путей к изображениям

        [NotMapped]
        public List<IFormFile>? Images { get; set; }
    }
}
