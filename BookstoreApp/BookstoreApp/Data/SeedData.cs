using BookstoreApp.Data;
using BookstoreApp.Models;

public static class CustomData
{
    public static void SeedData(WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetService<DatabaseContext>();

        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        var book1 = new Book
        {
            Title = "CQRS for Dummies",
            BookUUID = "9b0896fa-3880-4c2e-bfd6-925c87f22878",
            //IsReserved = false
        };
        var book2 = new Book
        {
            Title = "Visual Studio Tips",
            BookUUID = "0550818d-36ad-4a8d-9c3a-a715bf15de76",
            //IsReserved = false
        };
        var book3 = new Book
        {
            Title = "NHibernate Cookbook",
            BookUUID = "8e0f11f1-be5c-4dbc-8012-c19ce8cbe8e1",
            //IsReserved = false
        };

        var user1 = new User
        {
            Name = "TC",
            Password = "1234"
        };

        var user2 = new User
        {
            Name = "SQ",
            Password = "1234"
        };

        db.Books.Add(book1);
        db.Books.Add(book2);
        db.Books.Add(book3);

        db.Users.Add(user1);
        db.Users.Add(user2);

        db.SaveChanges();
    }
}

