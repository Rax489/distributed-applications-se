using Microsoft.AspNetCore.Mvc;
using MvcSmartStore.Data;
using MvcSmartStore.Models;

namespace MvcSmartStore.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _db;

        public UserController(AppDbContext db)
        {
            _db = db;
        }

        // GET: User/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: User/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (_db.Users.Any(u => u.Username.ToLower() == user.Username.ToLower()))
            {
                ModelState.AddModelError("Username", "Username already taken.");
                return View(user);
            }

            _db.Users.Add(user);
            _db.SaveChanges();

            TempData["PopUpMessage"] = "Registration successful.";
            return RedirectToAction("Login");
        }


        // GET: User/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: User/Login
        [HttpPost]
        public IActionResult Login(User user)
        {
            var existingUser = _db.Users.FirstOrDefault(u =>
                 u.Username == user.Username && u.Password == user.Password);

            if (existingUser != null)
            {
                HttpContext.Session.SetInt32("UserId", existingUser.Id);
                HttpContext.Session.SetString("IsAdmin", existingUser.IsAdmin ? "true" : "false");
                TempData["PopUpMessage"] = "Login successful.";
                return RedirectToAction("All", "Smartphone");
            }


            TempData["PopUpMessage"] = "Login failed: Invalid username or password.";
            return View(user);
        }

        // GET: User/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["PopUpMessage"] = "Logout successful.";
            return RedirectToAction("All", "Smartphone");
        }

        // GET: User/Allusers
        public IActionResult Allusers()
        {
            var users = _db.Users.ToList();
            return View(users);
        }
    }
}
