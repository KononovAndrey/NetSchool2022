namespace DSRNetSchool.API.Controllers;

using AutoMapper;
using DSRNetSchool.API.Controllers.Models;
using DSRNetSchool.Common.Responses;
using DSRNetSchool.Services.Books;
using Microsoft.AspNetCore.Mvc;


/// <summary>
/// Books controller
/// </summary>
/// <response code="400">Bad Request</response>
/// <response code="401">Unauthorized</response>
/// <response code="403">Forbidden</response>
/// <response code="404">Not Found</response>
[ProducesResponseType(typeof(ErrorResponse), 400)]
[Produces("application/json")]
[Route("api/v{version:apiVersion}/books")]
[ApiController]
[ApiVersion("1.0")]
public class BooksController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ILogger<BooksController> logger;
    private readonly IBookService bookService;

    public BooksController(IMapper mapper, ILogger<BooksController> logger, IBookService bookService)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.bookService = bookService;
    }


    /// <summary>
    /// Get books
    /// </summary>
    /// <param name="offset">Offset to the first element</param>
    /// <param name="limit">Count elements on the page</param>
    /// <response code="200">List of BookResponses</response>
    [ProducesResponseType(typeof(IEnumerable<BookResponse>), 200)]
    [HttpGet("")]
    public async Task<IEnumerable<BookResponse>> GetBooks([FromQuery] int offset = 0, [FromQuery] int limit = 10)
    {
        var books = await bookService.GetBooks(offset, limit);
        var response = mapper.Map<IEnumerable<BookResponse>>(books);

        return response;
    }

    /// <summary>
    /// Get books by Id
    /// </summary>
    /// <response code="200">BookResponse></response>
    [ProducesResponseType(typeof(BookResponse), 200)]
    [HttpGet("{id}")]
    public async Task<BookResponse> GetBookById([FromRoute] int id)
    {
        var book = await bookService.GetBook(id);
        var response = mapper.Map<BookResponse>(book);

        return response;
    }

    [HttpPost("")]
    public async Task<BookResponse> AddBook([FromBody] AddBookRequest request)
    {
        var model = mapper.Map<AddBookModel>(request);
        var book = await bookService.AddBook(model);
        var response = mapper.Map<BookResponse>(book);

        return response;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] UpdateBookRequest request)
    {
        var model = mapper.Map<UpdateBookModel>(request);
        await bookService.UpdateBook(id, model);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook([FromRoute] int id)
    {
        await bookService.DeleteBook(id);

        return Ok();
    }
}
