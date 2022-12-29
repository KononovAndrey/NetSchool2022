namespace DSRNetSchool.Web;

using System.Threading.Tasks;

public interface IBookService
{
    Task<IEnumerable<BookListItem>> GetBooks(int offset = 0, int limit = 10);
    Task<BookListItem> GetBook(int bookId);
    Task AddBook(BookModel model);
    Task EditBook(int bookId, BookModel model);
    Task DeleteBook(int bookId);

    Task<IEnumerable<AuthorModel>> GetAuthorList();
}
