using BookstoreApp.Data;
using BookstoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBook _books;

        public BookController(IBook books)
        {
            _books = books;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var userName = HttpContext.Session.GetString("UserName");
            if (userName != null)
            {
                ViewBag.UserId = userId;
                ViewBag.UserName = userName;
                var books = _books.GetAllBooks();
                ViewBag.Books = books;
                ViewBag.Bookings = _books.GetBookings();
                return View(books);
            }
            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public IActionResult Index(string searchName)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var userName = HttpContext.Session.GetString("UserName");
            ViewBag.SearchName = searchName;
            ViewBag.UserId = userId;
            ViewBag.UserName = userName;
            ViewBag.Bookings = _books.GetBookings();
            var books = _books.GetBooks(searchName);
            return View(books);
        }

        public IActionResult Reserve(int? id)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var userName = HttpContext.Session.GetString("UserName");
            var intUserId = Convert.ToInt16(userId);
            var book = _books.FindBook(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewBag.UserId = intUserId;

            //check if the book is booked
            var checkBooking = _books.GetBookingByBookId(id);

            if (checkBooking == null)
            {
                //booking not found
                var newBooking = _books.ReserveBooking(id, intUserId);
                ViewBag.BookingNumber = newBooking.Id;
                ViewBag.IsBookSuccess = true;
                return View();
            };

            ViewBag.IsBookSuccess = false;
            return View();
        }

    }
}


