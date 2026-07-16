using Trackerr.Core.Entities;

namespace Trackerr.Core.Abstractions.Repositories;

public interface ITrackRepository
{
    Task<List<Track>> GetAllAsync();
    Task<Track?> GetByIdAsync(Guid id);
    Task AddAsync(Track track);
    Task UpdateAsync(Track track);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}