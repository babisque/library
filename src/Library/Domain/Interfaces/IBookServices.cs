namespace Domain.Interfaces;

public interface IBookServices<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> CreateAsync(T createBookDto);
    Task UpdateAsync(Guid id, T updateBookDto);
    Task DeleteAsync(Guid id);
}