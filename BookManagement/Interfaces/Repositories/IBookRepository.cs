using BookManagement.Models.DataAccess;
using System.Data;

namespace BookManagement.API.Interfaces.Repositories
{
    public interface IBookRepository
    {
        public Task <List<BookDAO>> GetBookByPublisher();
        public Task <List<BookDAO>> GetBookByAuthor();
        public Task<int> InsertBooks(DataTable bookTable);
        public decimal GetTotalBookPrice();
    }
}
