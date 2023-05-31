using BookstoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApp.Data
{
    public interface IBook
    {
        public Book[] GetAllBooks();
        public Book[] GetBooks(string searchName);
        public Book? FindBook(int? id);
        public Booking[] GetBookings();
        public Booking? GetBookingByBookId(int? bookId);
        public Booking? ReserveBooking(int? bookId, int? userId);
    }
}
