using CarAdApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Motoland.Models;

namespace CarAdApp.Controllers
{
    public class CarAdsController : Controller
    {
        private readonly CarAdDbContext _context;

        public CarAdsController(CarAdDbContext context)
        {
            _context = context;
        }


        // GET: CarAds

        [HttpGet]
        public async Task<IActionResult> User_Login()
        {
            var carAds = await _context.CarAds.ToListAsync(); // Получаем все объявления из базы данных
            return View(carAds); // Передаем их в представление
        }


        // GET: CarAds/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Make,Model,Year,Price,Description,Images")] CarAd carAd)
        {
            if (ModelState.IsValid)
            {
                // Проверяем, есть ли загруженные изображения
                if (carAd.Images != null && carAd.Images.Count > 0)
                {
                    var imagePaths = new List<string>();

                    foreach (var image in carAd.Images)
                    {
                        if (image.Length > 0)
                        {
                            // Путь для сохранения файлов
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", image.FileName);

                            // Сохраняем файл
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await image.CopyToAsync(stream);
                            }

                            // Добавляем путь к изображению
                            imagePaths.Add("/images/" + image.FileName);
                        }
                    }

                    // Сохраняем пути к изображениям в виде строки, разделенной запятыми
                    carAd.ImagePaths = string.Join(",", imagePaths);
                }

                // Сохраняем данные объявления
                _context.Add(carAd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carAd);
        }



        // GET: CarAds/Edit/5
        [HttpGet("/CarAds/Edit/{id?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarAds == null)
            {
                return NotFound();
            }

            var carAd = await _context.CarAds.FindAsync(id);
            if (carAd == null)
            {
                return NotFound();
            }
            return View(carAd);
        }

        // POST: CarAds/Edit/5
        [HttpPost("/CarAds/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model,Year,Price,Description")] CarAd carAd)
        {
            if (id != carAd.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carAd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarAdExists(carAd.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carAd);
        }


        // GET: CarAds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarAds == null)
            {
                return NotFound();
            }

            var carAd = await _context.CarAds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carAd == null)
            {
                return NotFound();
            }

            return View(carAd);
        }

        // POST: CarAds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarAds == null)
            {
                return Problem("Entity set 'CarAdDbContext.CarAds'  is null.");
            }
            var carAd = await _context.CarAds.FindAsync(id);
            if (carAd != null)
            {
                _context.CarAds.Remove(carAd);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarAdExists(int id)
        {
            return _context.CarAds.Any(e => e.Id == id);
        }
    }
}
