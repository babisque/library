using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IBookRepository Books { get; }
    Task<int> SaveChangesAsync();
}