using BookManagement.API.Enums;
using BookManagement.API.Models;
using BookManagement.Interfaces.Services;
using BookManagement.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [ApiController]
    [Route("api/1.0/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;
        public BooksController(IBookService bookService,
            ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet("books-sort-publisher")]
        public async Task<IActionResult> GetBooksByPublisher()
        {
            try
            {
                var books = await _bookService.GetBookByPublisherAsync();
                if (books is not null)
                {
                    _logger.LogInformation("{MethodName} - Books fetched successfully.",
                        nameof(GetBooksByPublisher));

                    return Ok(new APIResult(
                        APIResultStatus.Success,
                        APIResultMessages.GetMessage(APIResultStatus.Success),
                        books
                    ));
                }

                _logger.LogWarning("{MethodName} - Process unsuccessful - books not found",
                    nameof(GetBooksByPublisher));

                return NotFound(new APIResult(
                    APIResultStatus.NotFound,
                    APIResultMessages.GetMessage(APIResultStatus.NotFound)
                ));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{MethodName} - Exception occurred while processing your request.",
                    nameof(GetBooksByPublisher));

                return StatusCode(StatusCodes.Status500InternalServerError,
                    new APIResult(APIResultStatus.Error, APIResultMessages.GetMessage(APIResultStatus.Error),
                        exception: ex.Message));
            }
        }

        [HttpGet("books-sort-author")]
        public async Task<IActionResult> GetBooksByAuthor()
        {
            try
            {
                var booksResult = await _bookService.GetBookByAuthorAsync();
                if (booksResult is not null)
                {
                    _logger.LogInformation("{MethodName} - Process successful.",
                        nameof(GetBooksByAuthor));

                    return Ok(new APIResult(
                        APIResultStatus.Success,
                        APIResultMessages.GetMessage(APIResultStatus.Success),
                        booksResult
                    ));
                }

                _logger.LogWarning("{MethodName} - Process unsuccessful.",
                    nameof(GetBooksByAuthor));

                return NotFound(new APIResult(
                    APIResultStatus.NotFound,
                    APIResultMessages.GetMessage(APIResultStatus.NotFound)
                ));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{MethodName} - Exception occurred while processing your request.",
                    nameof(GetBooksByAuthor));

                return StatusCode(StatusCodes.Status500InternalServerError,
                    new APIResult(APIResultStatus.Error, APIResultMessages.GetMessage(APIResultStatus.Error),
                        exception: ex.Message));
            }
        }

        [HttpPost("create-books")]
        public async Task<IActionResult> CreateAsync([FromBody] List<Books> books)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation("{MethodName} :: Model validation failed.",
                       nameof(CreateAsync));

                    return BadRequest(new APIResult(
                        APIResultStatus.ValidationError,
                        APIResultMessages.GetMessage(APIResultStatus.ValidationError),
                        ModelState
                    ));
                }

                var booksResult = await _bookService.InsertBooksAsync(books);
                if (booksResult > 0)
                {
                    _logger.LogInformation("{MethodName} - Process successful.",
                        nameof(CreateAsync));

                    return Ok(new APIResult(
                        APIResultStatus.Success,
                        APIResultMessages.GetMessage(APIResultStatus.Success),
                        booksResult
                    ));
                }

                _logger.LogWarning("{MethodName} - Process unsuccessful.",
                    nameof(CreateAsync));

                return BadRequest(new APIResult(
                    APIResultStatus.Error,
                    APIResultMessages.GetMessage(APIResultStatus.Error)
                ));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{MethodName} - Exception occurred while processing your request.",
                    nameof(CreateAsync));

                return StatusCode(StatusCodes.Status500InternalServerError,
                    new APIResult(APIResultStatus.Error, APIResultMessages.GetMessage(APIResultStatus.Error),
                        exception: ex.Message));
            }
        }

        [HttpGet("total-price")]
        public async Task<IActionResult> GetTotalPrice()
        {
            try
            {
                var totalPrice = await _bookService.GetTotalPrice();
                if (totalPrice >= 0)
                {
                    _logger.LogInformation("{MethodName} - Process successful.",
                        nameof(GetTotalPrice));

                    return Ok(new APIResult(
                        APIResultStatus.Success,
                        APIResultMessages.GetMessage(APIResultStatus.Success),
                        totalPrice
                    ));
                }

                _logger.LogWarning("{MethodName} - Process unsuccessful.",
                    nameof(GetTotalPrice));

                return NotFound(new APIResult(
                    APIResultStatus.NotFound,
                    APIResultMessages.GetMessage(APIResultStatus.NotFound)
                ));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{MethodName} - Exception occurred while processing your request.",
                    nameof(GetTotalPrice));

                return StatusCode(StatusCodes.Status500InternalServerError,
                    new APIResult(APIResultStatus.Error, APIResultMessages.GetMessage(APIResultStatus.Error),
                        exception: ex.Message));
            }
        }
    }
}
