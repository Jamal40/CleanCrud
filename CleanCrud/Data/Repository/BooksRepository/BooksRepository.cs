using CleanCrud.Models;

namespace CleanCrud.Data;

public class BooksRepository : GenericRepo<Book>, IBooksRepository
{
    private BookContext _context;
    public BooksRepository(BookContext injectedContext) : base(injectedContext)
    {
        _context = injectedContext;
    }

    public List<Book> GetBooksByAuthorName(string AuthorName)
    {
        return _context.Books.Where(b => b.AuthorName == AuthorName).ToList();
    }
}
