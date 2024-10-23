using System.ComponentModel.DataAnnotations;

namespace Motoland.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; } // Flaga, która określa czy użytkownik jest adminem
    }
}
