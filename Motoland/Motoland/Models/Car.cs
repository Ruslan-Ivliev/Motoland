namespace Motoland.Models
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public int car_mileage { get; set; }
        public int engine_capacity { get; set; }


        public string ImageUrl { get; set; }
    }
}