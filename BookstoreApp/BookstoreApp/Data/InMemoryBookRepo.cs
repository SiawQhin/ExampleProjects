using BookstoreApp.Models;

namespace BookstoreApp.Data
{
    public class InMemoryBookRepo :IBook
    {
        public Book[] GetAllBooks()
        {
            return GlobalData.books.ToArray();
        }

        public Book[] GetBooks(string searchName)
        {
            if ((searchName != null) && (searchName.Length > 0))
            {
                return GlobalData.books.Where(b => b.Title.Contains(searchName)).ToArray();
            }
            return GlobalData.books.ToArray();
        }
        public Book? FindBook(int? id)
        {
            return GlobalData.books.FirstOrDefault(b => b.Id == id);
        }

        public Booking[] GetBookings()
        {
            return GlobalData.bookings.ToArray();
        }

        public Booking? ReserveBooking(int? bookId, int? userId)
        {
            if (bookId == null || userId == null) //check if bookId or userId is null
            {
                return null;
            }
            var bookingList = GetBookings();
            var currentBookingId = 0;

            if (bookingList != null && bookingList.Length > 0 && bookingList.Last() != null) 
            { 
                currentBookingId = bookingList.Last().Id;
            }
            var newBooking = new Booking
            {
                Id = currentBookingId + 1,
                BookId = (int)bookId,
                UserId = (int)userId,
            };
            GlobalData.bookings.Add(newBooking);

            return newBooking;
        }

        public Booking? GetBookingByBookId(int? bookId)
        {
            return GetBookings().FirstOrDefault(b => b.BookId == bookId);
        }
    }
}
