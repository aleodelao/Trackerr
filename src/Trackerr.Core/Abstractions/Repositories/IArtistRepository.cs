using Trackerr.Core.Entities;

namespace Trackerr.Core.Abstractions.Repositories;

public interface IArtistRepository
{
    Task<List<Artist>> GetAllAsync();
    Task<Artist?> GetByIdAsync(Guid id);
    Task AddAsync(Artist artist);
    Task UpdateAsync(Artist artist);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}