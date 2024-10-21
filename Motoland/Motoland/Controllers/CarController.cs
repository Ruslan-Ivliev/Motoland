using Microsoft.AspNetCore.Mvc;
using Motoland.Models;
using System.Collections.Generic;
using System.Linq;


    namespace Motoland.Controllers
    {
        public class CarController : Controller
        {
            // Symulowana baza danych samochodów
            private static List<Car> cars = new List<Car>
        {
            new Car
            {
                Id = 1,
                Brand = "BMW",
                Model = "X5",
                Year = 2020,
                Price = 150000,
                ImageUrl = "https://example.com/bmw-x5.jpg",
                Description = "Przestronny SUV z napędem na wszystkie koła, idealny dla rodziny.",
                Mileage = 25000,
                EngineCapacity = 3000
            },
            new Car
            {
                Id = 2,
                Brand = "Audi",
                Model = "A4",
                Year = 2019,
                Price = 120000,
                ImageUrl = "https://example.com/audi-a4.jpg",
                Description = "Elegancki sedan z nowoczesnymi technologiami i komfortowym wnętrzem.",
                Mileage = 30000,
                EngineCapacity = 2000
            },
            new Car
            {
                Id = 3,
                Brand = "Mercedes",
                Model = "C-Class",
                Year = 2021,
                Price = 130000,
                ImageUrl = "https://example.com/mercedes-cclass.jpg",
                Description = "Luksusowy samochód z zaawansowanymi funkcjami bezpieczeństwa.",
                Mileage = 15000,
                EngineCapacity = 2500
            }
            // Dodaj więcej samochodów według potrzeb
        };

            // Akcja do wyświetlania listy samochodów
            public IActionResult Index()
            {
                return View(cars);
            }

            // Akcja do filtrowania samochodów
            [HttpPost]
            public IActionResult Filter(string brand, string model, decimal? priceMin, decimal? priceMax, int? year, int? car_mileage, int? engine_capacity)
            {
                var filteredCars = cars.AsQueryable();

                if (!string.IsNullOrEmpty(brand))
                    filteredCars = filteredCars.Where(c => c.Brand.ToLower() == brand.ToLower());

                if (!string.IsNullOrEmpty(model))
                    filteredCars = filteredCars.Where(c => c.Model.ToLower().Contains(model.ToLower()));

                if (priceMin.HasValue)
                    filteredCars = filteredCars.Where(c => c.Price >= priceMin.Value);

                if (priceMax.HasValue)
                    filteredCars = filteredCars.Where(c => c.Price <= priceMax.Value);

                if (year.HasValue)
                    filteredCars = filteredCars.Where(c => c.Year == year.Value);

                if (car_mileage.HasValue)
                    filteredCars = filteredCars.Where(c => c.Mileage <= car_mileage.Value);

                if (engine_capacity.HasValue)
                    filteredCars = filteredCars.Where(c => c.EngineCapacity >= engine_capacity.Value);

                return View("User_Login", filteredCars.ToList());
            }
        }
    }


