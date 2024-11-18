using Domain.Entities;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author)
    {
        return await _context.Books
            .Where(b => b.Author.Contains(author))
            .ToListAsync();
    }

    public async Task<Book> GetBookByISBNAsync(string isbn)
    {
        return await _context.Books
            .FirstOrDefaultAsync(b => b.ISBN == isbn) ?? throw new InvalidOperationException();
    }
}