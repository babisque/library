using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IBookRepository _bookRepository;

    public UnitOfWork(ApplicationDbContext context, IBookRepository bookRepository)
    {
        _context = context;
        _bookRepository = bookRepository;
    }

    public IBookRepository Books => 
        _bookRepository ??= new BookRepository(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}