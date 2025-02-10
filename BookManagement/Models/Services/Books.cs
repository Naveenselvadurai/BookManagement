using System.ComponentModel.DataAnnotations;

namespace BookManagement.Models.Services
{
    public class Books
    {
        [Required(ErrorMessage = "Publisher is required")] public string Publisher { get; set; } = string.Empty;
        [Required(ErrorMessage = "Title is required")] public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "AuthorLastName required")] public string AuthorLastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "AuthorFirstName required")] public string AuthorFirstName { get; set; } = string.Empty;
        public decimal Price { get; set; }

    }
}
