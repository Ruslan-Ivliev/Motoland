using Microsoft.AspNetCore.Mvc;
using Motoland.Models;
using System.Collections.Generic;
using System.Linq;

namespace Motoland.CarController
{
    public class CarController : Controller
    {
        // Przykładowe dane samochodów
        private static List<Car> cars = new List<Car>
        {
            new Car { Brand = "BMW", Model = "X5", Year = 2018, Price = 120000, car_mileage = 12000,engine_capacity = 1900, ImageUrl = "https://via.placeholder.com/300x200" },
            new Car { Brand = "Audi", Model = "A6", Year = 2019, Price = 150000,car_mileage = 12000,engine_capacity = 1900, ImageUrl = "https://via.placeholder.com/300x200" },
            new Car { Brand = "Mercedes", Model = "C-Class", Year = 2020, Price = 170000,car_mileage = 12000,engine_capacity = 1900, ImageUrl = "https://via.placeholder.com/300x200" }
        };

        // Metoda akcji wyświetlająca stronę z listą samochodów
        public ActionResult Index()
        {
            // Sprawdź, czy lista samochodów jest null i zwróć pustą listę, jeśli tak
            var carsList = cars ?? new List<Car>();
            return View(carsList);
        }

        // Akcja do obsługi formularza filtrowania
        [HttpPost]
        public ActionResult Filter(string brand, string model, int? priceMin, int? priceMax, int? year, int? carmilage, int? enginecapacity)
        {
            // Filtruj samochody na podstawie przekazanych parametrów
            var filteredCars = cars.AsQueryable();

            if (!string.IsNullOrEmpty(brand))
            {
                filteredCars = filteredCars.Where(c => c.Brand.ToLower() == brand.ToLower());
            }

            if (!string.IsNullOrEmpty(model))
            {
                filteredCars = filteredCars.Where(c => c.Model.ToLower().Contains(model.ToLower()));
            }

            if (priceMin.HasValue)
            {
                filteredCars = filteredCars.Where(c => c.Price >= priceMin.Value);
            }

            if (priceMax.HasValue)
            {
                filteredCars = filteredCars.Where(c => c.Price <= priceMax.Value);
            }

            if (year.HasValue)
            {
                filteredCars = filteredCars.Where(c => c.Year == year.Value);
            }

            if (carmilage.HasValue)
            {
                filteredCars = filteredCars.Where(c => c.car_mileage == carmilage.Value);
            }
            if (enginecapacity.HasValue)
            {
                filteredCars = filteredCars.Where(c => c.engine_capacity == enginecapacity.Value);
            }
            // Sprawdź, czy wynik filtrowania jest null
            var resultList = filteredCars.ToList() ?? new List<Car>();

            // Przekazanie przefiltrowanej listy do widoku
            return View("Index", resultList);
        }
    }
}