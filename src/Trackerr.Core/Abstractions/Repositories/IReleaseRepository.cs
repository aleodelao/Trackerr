using Trackerr.Core.Entities;

namespace Trackerr.Core.Abstractions.Repositories;

public interface IReleaseRepository
{
    Task<List<Release>> GetAllAsync();
    Task<Release?> GetByIdAsync(Guid id);
    Task AddAsync(Release release);
    Task UpdateAsync(Release release);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}