namespace DSRNetSchool.Services.Books;

using AutoMapper;
using DSRNetSchool.Common.Exceptions;
using DSRNetSchool.Common.Validator;
using DSRNetSchool.Context;
using DSRNetSchool.Context.Entities;
using DSRNetSchool.Services.Cache;
using Microsoft.EntityFrameworkCore;

public class BookService : IBookService
{
    private const string contextCacheKey = "books_cache_key";

    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;
    private readonly ICacheService cacheService;
    private readonly IModelValidator<AddBookModel> addBookModelValidator;
    private readonly IModelValidator<UpdateBookModel> updateBookModelValidator;

    public BookService(
        IDbContextFactory<MainDbContext> contextFactory,
        IMapper mapper,
        ICacheService cacheService,
        IModelValidator<AddBookModel> addBookModelValidator,
        IModelValidator<UpdateBookModel> updateBookModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.cacheService = cacheService;
        this.addBookModelValidator = addBookModelValidator;
        this.updateBookModelValidator = updateBookModelValidator;
    }

    public async Task<IEnumerable<BookModel>> GetBooks(int offset = 0, int limit = 10)
    {
        //try
        //{
        //    var cached_data = await cacheService.Get<IEnumerable<BookModel>>(contextCacheKey);
        //    if (cached_data != null)
        //        return cached_data;
        //}
        //catch
        //{
        //    // Put log message here
        //}

        //await Task.Delay(5000);




        using var context = await contextFactory.CreateDbContextAsync();

        var books = context
            .Books
            .Include(x => x.Author)
            .AsQueryable();

        books = books
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 1000)));

        var data = (await books.ToListAsync()).Select(book => mapper.Map<BookModel>(book));

        await cacheService.Put(contextCacheKey, data, TimeSpan.FromSeconds(30));

        return data;
    }

    public async Task<BookModel> GetBook(int id)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var book = await context.Books.Include(x => x.Author).FirstOrDefaultAsync(x => x.Id.Equals(id));

        var data = mapper.Map<BookModel>(book);

        return data;
    }
    public async Task<BookModel> AddBook(AddBookModel model)
    {
        addBookModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var book = mapper.Map<Book>(model);
        await context.Books.AddAsync(book);
        context.SaveChanges();


        //await cacheService.Delete(contextCacheKey);

        return mapper.Map<BookModel>(book);
    }

    public async Task UpdateBook(int bookId, UpdateBookModel model)
    {
        updateBookModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var book = await context.Books.FirstOrDefaultAsync(x => x.Id.Equals(bookId));

        ProcessException.ThrowIf(() => book is null, $"The book (id: {bookId}) was not found");

        book = mapper.Map(model, book);

        context.Books.Update(book);
        context.SaveChanges();
    }

    public async Task DeleteBook(int bookId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var book = await context.Books.FirstOrDefaultAsync(x => x.Id.Equals(bookId))
            ?? throw new ProcessException($"The book (id: {bookId}) was not found");

        context.Remove(book);
        context.SaveChanges();
    }
}
