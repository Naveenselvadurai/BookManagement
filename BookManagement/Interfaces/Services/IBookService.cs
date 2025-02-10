using BookManagement.API.Models.Services;
using BookManagement.Models.Services;

namespace BookManagement.Interfaces.Services
{
    public interface IBookService
    {
        Task<List<BooksResponse?>> GetBookByPublisherAsync();
        Task<List<BooksResponse?>> GetBookByAuthorAsync();
        Task <int>InsertBooksAsync(List<Books> books);
        Task <decimal> GetTotalPrice();
    }
}
