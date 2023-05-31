using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string BookUUID { get; set; }
        public string Title { get; set; }

       // public bool IsReserved { get; set; }

        //public Book(int id, string title, string bookUUID) //IsReserved is defaulted to false
        //{
        //    Id = id;
        //    Title = title;
        //    IsReserved = false;
        //    BookUUID = bookUUID;
        //}
    }
}
