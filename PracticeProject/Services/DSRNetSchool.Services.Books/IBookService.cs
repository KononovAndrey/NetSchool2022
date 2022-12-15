namespace DSRNetSchool.Services.Books;

public interface IBookService
{
    Task<IEnumerable<BookModel>> GetBooks(int offset = 0, int limit = 10);
    Task<BookModel> GetBook(int bookId);
    Task<BookModel> AddBook(AddBookModel model);
    Task UpdateBook(int id, UpdateBookModel model);
    Task DeleteBook(int bookId);
}