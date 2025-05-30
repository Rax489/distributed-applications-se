using Microsoft.AspNetCore.Mvc;
using MvcSmartStore.Data;

namespace MvcSmartStore.Controllers
{
    public class SmartphoneController : Controller
    {

        
        private readonly AppDbContext _db;

        public SmartphoneController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult All(string brand, float? minPrice, float? maxPrice, int? ram, int? refresh_rate, int? storage)//?Nullable
        {
            var query = _db.Smartphones.AsQueryable();

            if (!string.IsNullOrEmpty(brand)) query = query.Where(r => r.Brand == brand);
            if (minPrice.HasValue) query = query.Where(r => r.Price >= minPrice.Value);                
            if (maxPrice.HasValue) query = query.Where(r => r.Price <= maxPrice.Value);                
            if (ram.HasValue) query = query.Where(r => r.Ram == ram.Value);
            //dodane
            if(refresh_rate.HasValue) query = query.Where(r => r.Refresh_rate ==  refresh_rate.Value);
            if(storage.HasValue) query = query.Where(r => r.Storage == storage.Value);

            // Dropdown Data
            ViewBag.Brands = _db.Smartphones.Select(r => r.Brand).Distinct().ToList();
            ViewBag.Rams = _db.Smartphones.Select(r => r.Ram).Distinct().OrderBy(r => r).ToList();
            ViewBag.Refresh_rate = _db.Smartphones.Select(r => r.Refresh_rate).Distinct().OrderBy(r => r).ToList();
            ViewBag.Storage = _db.Smartphones.Select(r => r.Storage).Distinct().OrderBy(r=>r).ToList();

            var result = query.ToList();

            ViewBag.SelectedBrand = brand;
            ViewBag.SelectedMinPrice = minPrice;
            ViewBag.SelectedMaxPrice = maxPrice;
            ViewBag.SelectedRam = ram;
            ViewBag.SelectedRefreshRate = refresh_rate;
            ViewBag.SelectedStorage = storage;


            return View(result);
        }
        public IActionResult SpecificsOfPhone (int id)
        {
            var phone = _db.Smartphones.FirstOrDefault(r => r.Id == id);
            if (phone == null)
            {
                return NotFound();
            }
            return View(phone);
        }

    }

}
