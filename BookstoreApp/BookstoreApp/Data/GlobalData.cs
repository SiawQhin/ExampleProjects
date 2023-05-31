using BookstoreApp.Models;

namespace BookstoreApp.Data
{
    public static class GlobalData //add static class to GlobalData
    {
        public static List<Book> books;
        public static List<Booking> bookings;

        //new Book("9b0896fa-3880-4c2e-bfd6-925c87f22878", "CQRS for Dummies"),
        //new Book("0550818d-36ad-4a8d-9c3a-a715bf15de76", "Visual Studio Tips"),
        //new Book("8e0f11f1-be5c-4dbc-8012-c19ce8cbe8e1", "NHibernate Cookbook"),
        public static void SeedData()
        {
            books = new List<Book>();
            bookings = new List<Booking>();

            books.Add(new Book {
               Id = 1,
               BookUUID= "9b0896fa-3880-4c2e-bfd6-925c87f22878",
               Title= "CQRS for Dummies",
            });

            books.Add(new Book
            {
                Id = 2,
                BookUUID = "0550818d-36ad-4a8d-9c3a-a715bf15de76",
                Title = "Visual Studio Tips",
            });

            books.Add(new Book
            {
                Id = 3,
                BookUUID = "8e0f11f1-be5c-4dbc-8012-c19ce8cbe8e1",
                Title = "NHibernate Cookbook",
            });

        }
    }
}