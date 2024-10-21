namespace Motoland.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        // Nowe pole dla opisu
        public string Description { get; set; }

        // Opcjonalnie dodatkowe pola
        public int Mileage { get; set; }
        public int EngineCapacity { get; set; }
    }
}
