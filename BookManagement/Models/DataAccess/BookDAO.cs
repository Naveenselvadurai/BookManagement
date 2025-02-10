using System.ComponentModel.DataAnnotations;

namespace BookManagement.Models.DataAccess
{
    public class BookDAO
    {
        [Key]
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? AuthorLastName { get; set; }
        public string? AuthorFirstName { get; set; }
        public string? Publisher { get; set; }
        public decimal Price { get; set; }
    }
    public class BookPriceDAO
    {
        [Key]
        public int BookCount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
