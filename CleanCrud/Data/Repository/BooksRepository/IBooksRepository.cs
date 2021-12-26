using CleanCrud.Models;

namespace CleanCrud.Data;

internal interface IBooksRepository : IGenericRepo<Book>
{
    List<Book> GetBooksByAuthorName(string AuthorName);
}