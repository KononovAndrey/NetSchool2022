namespace DSRNetSchool.Web;

using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class BookService : IBookService
{
    private readonly HttpClient _httpClient;

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<BookListItem>> GetBooks(int offset = 0, int limit = 10)
    {
        string url = $"{Settings.ApiRoot}/v1/books?offset={offset}&limit={limit}";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<IEnumerable<BookListItem>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<BookListItem>();

        return data;
    }

    public async Task<BookListItem> GetBook(int bookId)
    {
        string url = $"{Settings.ApiRoot}/v1/books/{bookId}";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<BookListItem>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new BookListItem();

        return data;
    }

    public async Task AddBook(BookModel model)
    {
        string url = $"{Settings.ApiRoot}/v1/books";

        var body = JsonSerializer.Serialize(model);
        var request = new StringContent(body, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, request);

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }    
    
    public async Task EditBook(int bookId, BookModel model)
    {
        string url = $"{Settings.ApiRoot}/v1/books/{bookId}";

        var body = JsonSerializer.Serialize(model);
        var request = new StringContent(body, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync(url, request);

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }

    public async Task DeleteBook(int bookId)
    {
        string url = $"{Settings.ApiRoot}/v1/books/{bookId}";

        var response = await _httpClient.DeleteAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }

    public async Task<IEnumerable<AuthorModel>> GetAuthorList()
    {
        string url = $"{Settings.ApiRoot}/v1/authors";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<IEnumerable<AuthorModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<AuthorModel>();

        return data;
    }
}
