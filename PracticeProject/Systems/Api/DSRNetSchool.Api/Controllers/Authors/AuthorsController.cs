namespace DSRNetSchool.API.Controllers.Authors;

using AutoMapper;
using DSRNetSchool.API.Controllers.Authors.Models;
using DSRNetSchool.Common.Security;
using DSRNetSchool.Services.Authors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/v{version:apiVersion}/authors")]
[ApiController]
[ApiVersion("1.0")]
public class AuthorsController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ILogger<AuthorsController> logger;
    private readonly IAuthorService authorService;

    public AuthorsController(IMapper mapper, ILogger<AuthorsController> logger, IAuthorService authorService)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.authorService = authorService;
    }

    [HttpGet("")]
    //[Authorize(AppScopes.BooksRead)]
    public async Task<IEnumerable<AuthorResponse>> GetAuthors()
    {
        var books = await authorService.GetAuthors();
        var response = mapper.Map<IEnumerable<AuthorResponse>>(books);

        return response;
    }
}
