using BookManagement.API.Interfaces.Repositories;
using BookManagement.Context;
using BookManagement.Models.DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookContext _context;
        private ILogger<BookRepository> _logger;
        public BookRepository(BookContext context,
              ILogger<BookRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task <List<BookDAO>> GetBookByPublisher()
        {
            try
            {
                List<BookDAO> bookDAO = await _context.Books.FromSqlRaw("EXEC GET_BOOKS_SORT_PUBLISHER").ToListAsync();
                return bookDAO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occurred while processing your request.: {Ex}", ex);
                throw;
            }
        }
        public async Task<List<BookDAO>> GetBookByAuthor()
        {
            try
            {
                List<BookDAO> bookDAO = await _context.Books.FromSqlRaw("EXEC GET_BOOKS_SORT_AUTHOR").ToListAsync();
                return bookDAO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occurred while processing your request.: {Ex}", ex);
                throw;
            }
        }
        public async Task<int> InsertBooks(DataTable bookTable)
        {
            try
            {
                var parameter = new SqlParameter("@BookData", SqlDbType.Structured)
                {
                    TypeName = "dbo.BOOK_TABLE_TYPE",
                    Value = bookTable
                };
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC INSERT_BOOKS @BookData", parameter);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occurred while processing your request.: {Ex}", ex);
                throw;
            }
        }
        public decimal GetTotalBookPrice()
        {
            try
            {
                var totalPrice =  _context.BookPrices.FromSqlRaw("EXEC GET_TOTAL_BOOK_PRICE").ToList().First();
                return totalPrice.TotalPrice;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occurred while processing your request.: {Ex}", ex);
                throw;
            }
        }
    }
}
