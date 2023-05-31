using BookstoreApp.Models;
using SQLitePCL;

namespace BookstoreApp.Data
{
    public class DbBookRepo : IBook
    {
        private readonly DatabaseContext _db;

        public DbBookRepo(DatabaseContext db)
        {
            _db = db;
        }

        public Book[] GetAllBooks()
        {
            return _db.Books.ToArray();
        }

        public Book[] GetBooks(string searchName)
        {
            if ((searchName != null) && (searchName.Length > 0))
            {
                return _db.Books.Where(b => b.Title.Contains(searchName)).ToArray();
            }
            return _db.Books.ToArray();
        }
        public Book? FindBook(int? id)
        {
            return _db.Books.FirstOrDefault(b => b.Id == id);
        }

        public Booking[] GetBookings()
        {
            return _db.Bookings.ToArray();
        }

        public Booking? ReserveBooking(int? bookId, int? userId)
        {
            if (bookId == null || userId == null) //check if bookId or userId is null
            {
                return null;
            }
            var newBooking = _db.Bookings.Add(new Booking
            {
                BookId = (int)bookId,
                UserId = (int)userId,

            });
            _db.SaveChanges();
            return newBooking.Entity;
        }

        public Booking? GetBookingByBookId(int? bookId)
        {
            return GetBookings().FirstOrDefault(b => b.BookId == bookId);
        }
    }
}
