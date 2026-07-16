using Microsoft.EntityFrameworkCore;
using Trackerr.Core.Entities;
using Trackerr.Core.Abstractions.Repositories;

namespace Trackerr.Infrastructure.Persistence.Repositories;

public class ReleaseRepository : IReleaseRepository
{
    private readonly TrackerrDbContext _db;

    public ReleaseRepository(TrackerrDbContext db)
    {
        _db = db;
    }

    public async Task<List<Release>> GetAllAsync()
    {
        return await _db.Releases.ToListAsync();
    }

    public async Task<Release?> GetByIdAsync(Guid id)
    {
        return await _db.Releases
            .Include(r => r.Artist)
            .Include(r => r.Tracks)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task AddAsync(Release release)
    {
        await _db.Releases.AddAsync(release);
    }

    public Task UpdateAsync(Release release)
    {
        _db.Releases.Update(release);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var release = await _db.Releases.FindAsync(id);

        if (release != null)
            _db.Releases.Remove(release);
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}