using Trackerr.Core.Entities;

namespace Trackerr.Core.Abstractions.Repositories;

public interface IArtistRepository
{
    Task<IEnumerable<Artist>> GetAllAsync(string? search);
    Task<Artist?> GetByIdAsync(Guid id);
    Task AddAsync(Artist artist);
    Task UpdateAsync(Artist artist);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}