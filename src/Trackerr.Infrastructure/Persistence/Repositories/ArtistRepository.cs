using Microsoft.EntityFrameworkCore;
using Trackerr.Core.Entities;
using Trackerr.Core.Abstractions.Repositories;

namespace Trackerr.Infrastructure.Persistence.Repositories;

public class ArtistRepository : IArtistRepository
{
    private readonly TrackerrDbContext _db;

    public ArtistRepository(TrackerrDbContext db)
    {
        _db = db;
    }

    public async Task<List<Artist>> GetAllAsync()
    {
        return await _db.Artists.ToListAsync();
    }

    public async Task<Artist?> GetByIdAsync(Guid id)
    {
        return await _db.Artists
            .Include(a => a.Releases)
            .ThenInclude(r => r.Tracks)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAsync(Artist artist)
    {
        await _db.Artists.AddAsync(artist);
    }

    public Task UpdateAsync(Artist artist)
    {
        _db.Artists.Update(artist);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var artist = await _db.Artists.FindAsync(id);

        if (artist != null)
            _db.Artists.Remove(artist);
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}