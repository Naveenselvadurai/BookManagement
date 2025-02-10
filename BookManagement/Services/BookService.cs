using BookManagement.API.Enums;
using BookManagement.API.Exceptions;
using BookManagement.API.Interfaces.Repositories;
using BookManagement.API.Models.Services;
using BookManagement.Interfaces.Services;
using BookManagement.Models.DataAccess;
using BookManagement.Models.Services;
using System.Data;

namespace BookManagement.Services
{
    public class BookService : IBookService
    {
        private readonly ILogger<BookService> _logger;
        private readonly IBookRepository _bookRepository;
        public BookService(ILogger<BookService> logger,
                           IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }
        public async Task<List<BooksResponse?>> GetBookByPublisherAsync()
        {
            var books = await _bookRepository.GetBookByPublisher();
            if (books != null)
            {
                _logger.LogInformation("Books details sucessfully fetched");
                return MapformBookDAOToBooks(books);
            }

            _logger.LogWarning("Book details not found");
            throw new ApiException("Book details not found", (int)ErrorCodes.BookDetailsNotFound);

        }
        public async Task<List<BooksResponse?>> GetBookByAuthorAsync()
        {
            var books = await _bookRepository.GetBookByAuthor();
            if (books != null)
            {
                _logger.LogInformation("Books details sucessfully fetched");
                return MapformBookDAOToBooks(books);
            }

            _logger.LogWarning("Book details not found");
            throw new ApiException("Book details not found", (int)ErrorCodes.BookDetailsNotFound);
        }
        public async Task<int> InsertBooksAsync(List<Books> books)
        {
            if (books == null)
            {
                throw new ArgumentNullException(nameof(books));
            }

            var booksResult = await _bookRepository.InsertBooks(ConvertBooksToDataTable(books));
            return booksResult;
        }
        public async Task<decimal> GetTotalPrice()
        {
            var totalprice = _bookRepository.GetTotalBookPrice();

            if(totalprice >= 0)
            {
                _logger.LogInformation("Total price sucessfully fetched");
                return await Task.FromResult(totalprice);
            }
            _logger.LogWarning("Invalid total price");
            throw new ApiException("Invalid total price", (int)ErrorCodes.InvalidTotalPrice);
        }
        private List<BooksResponse?> MapformBookDAOToBooks(List<BookDAO> bookDAOs)
        {
            List<BooksResponse?> books = new List<BooksResponse?>();
            foreach (BookDAO bookDAO in bookDAOs)
            {
                BooksResponse book = new BooksResponse();
                book.Publisher = bookDAO.Publisher!;
                book.Title = bookDAO.Title!;
                book.AuthorFirstName = bookDAO.Title!;
                book.AuthorLastName = bookDAO.Title!;
                book.Price = bookDAO.Price;
                books.Add(book);
            }
            return books;
        }
        private DataTable ConvertBooksToDataTable(List<Books> books)
        {
            DataTable bookTable = new DataTable();
            bookTable.Columns.Add("Publisher", typeof(string));
            bookTable.Columns.Add("Title", typeof(string));
            bookTable.Columns.Add("AuthorLastName", typeof(string));
            bookTable.Columns.Add("AuthorFirstName", typeof(string));
            bookTable.Columns.Add("Price", typeof(decimal));

            foreach (Books book in books)
            {
                DataRow dataRow = bookTable.NewRow();
                dataRow["Publisher"] = book.Publisher;
                dataRow["Title"] = book.Title;
                dataRow["AuthorLastName"] = book.AuthorLastName;
                dataRow["AuthorFirstName"] = book.AuthorFirstName;
                dataRow["Price"] = book.Price;
                bookTable.Rows.Add(dataRow);
            }
            return bookTable;
        }
    }
}
