using BookstoreApp.Data;
using BookstoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApp.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _db;
        public UserController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user) 
        { 
            if (ModelState.IsValid)
            {
                var usr = _db.Users
                    .Where(u => u.Name.Equals(user.Name) && u.Password.Equals(user.Password)).FirstOrDefault();

                if (usr != null)
                {
                    HttpContext.Session.SetString("UserId", usr.Id.ToString());
                    HttpContext.Session.SetString("UserName", usr.Name.ToString());
                    return RedirectToAction("Index","Book");
                }
            }
            return View(user);
        }
    }
}
