using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public interface IBookRepository : IRepository<Book>
{
    Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author);
    Task<Book> GetBookByISBNAsync(string isbn);
}