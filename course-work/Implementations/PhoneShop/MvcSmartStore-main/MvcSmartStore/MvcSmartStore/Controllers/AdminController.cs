using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcSmartStore.Data;
using MvcSmartStore.Models;

[Authorize]
public class AdminController : Controller
{
    private readonly AppDbContext _db;

    public AdminController(AppDbContext db)
    {
        _db = db;
    }

    private bool IsAdmin()
    {
        var isAdmin = HttpContext.Session.GetString("IsAdmin");
        return isAdmin == "true";
    }

    [HttpPost]
    public IActionResult ToggleAdmin(int id)
    {
        var user = _db.Users.Find(id);
        if (user == null)
            return NotFound();

        user.IsAdmin = !user.IsAdmin;
        _db.SaveChanges();

        TempData["PopUpMessage"] = $"User {(user.IsAdmin ? "promoted to" : "removed from")} admin successfully!";
        return RedirectToAction("Allusers", "User");
    }

    // --- Smartphones ---

    public IActionResult Smartphones()
    {
        var phones = _db.Smartphones.ToList();
        return View(phones);
    }

    [HttpGet]
    [HttpGet]
    public IActionResult EditPhone(int id)
    {
        var phone = _db.Smartphones.Find(id);
        if (phone == null) return NotFound();
        return View("~/Views/User/EditPhone.cshtml", phone);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditPhoneConfirm(Smartphone phone)
    {
        if (!ModelState.IsValid)
        {
            return View("~/Views/User/EditPhone.cshtml", phone);
        }

        var existingPhone = _db.Smartphones.FirstOrDefault(p => p.Id == phone.Id);
        if (existingPhone == null)
        {
            return NotFound();
        }

        existingPhone.Brand = phone.Brand;
        existingPhone.Model = phone.Model;
        existingPhone.Price = phone.Price;
        existingPhone.Selling_platform = phone.Selling_platform;
        existingPhone.Rating = phone.Rating;
        existingPhone.Refresh_rate = phone.Refresh_rate;
        existingPhone.Screen_size = phone.Screen_size;
        existingPhone.Ram = phone.Ram;
        existingPhone.Storage = phone.Storage;
        existingPhone.Processor = phone.Processor;
        existingPhone.Camera_setup = phone.Camera_setup;
        existingPhone.imgURL = phone.imgURL;

        _db.SaveChanges();

        TempData["PopUpMessage"] = "Editing phone was completed successfully!";
        return RedirectToAction("Dashboard");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddPhone(Smartphone phone)
    {
        if (!ModelState.IsValid)
        {
            return View("~/Views/User/AddPhone.cshtml", phone);
        }

        _db.Smartphones.Add(phone);
        _db.SaveChanges();
        TempData["PopUpMessage"] = "Phone added successfully!";
        return RedirectToAction("Dashboard");
    }



    [HttpGet]
    public IActionResult DeletePhone(int id)
    {
        var phone = _db.Smartphones.Find(id);
        if (phone == null) return NotFound();
        return View("~/Views/User/DeletePhone.cshtml", phone);
    }

    [HttpPost, ActionName("DeletePhoneConfirmed")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePhoneConfirmed(int id)
    {
        var phone = _db.Smartphones.Find(id);
        if (phone == null) return NotFound();

        _db.Smartphones.Remove(phone);
        _db.SaveChanges();
        TempData["PopUpMessage"] = "Phone deleted successfully!";
        return RedirectToAction("Dashboard");
    }


    public IActionResult Users()
    {
        var users = _db.Users.ToList();
        return View(users);
    }

    [HttpGet]
    public IActionResult EditUser(int id)
    {
        var user = _db.Users.Find(id);
        if (user == null) return NotFound();
        return View(user);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteUser(int id)
    {
        var user = _db.Users.Find(id);
        if (user == null) return NotFound();

        _db.Users.Remove(user);
        _db.SaveChanges();
        TempData["PopUpMessage"] = "User deleted successfully!";
        return RedirectToAction("Allusers", "User");
    }

    public IActionResult Dashboard(string phoneSearch = "")
    {
        var phonesQuery = _db.Smartphones.AsQueryable();
        if (!string.IsNullOrWhiteSpace(phoneSearch))
        {
            phonesQuery = phonesQuery.Where(p => p.Brand.Contains(phoneSearch) || p.Model.Contains(phoneSearch));
        }
        var phones = phonesQuery.ToList();

        var model = Tuple.Create(phones, phoneSearch);
        return View("~/Views/User/ManagePhones.cshtml", model);
    }
}
