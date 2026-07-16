using Trackerr.Core.Entities;

namespace Trackerr.Core.Abstractions.Repositories;

public interface ITrackFileRepository
{
    Task<List<TrackFile>> GetAllAsync();
    Task<TrackFile?> GetByIdAsync(Guid id);
    Task AddAsync(TrackFile trackFile);
    Task UpdateAsync(TrackFile trackFile);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}