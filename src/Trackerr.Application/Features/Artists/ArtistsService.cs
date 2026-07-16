using Trackerr.Application.Features.Artists.DTOs;
using Trackerr.Core.Entities;
using Trackerr.Core.Abstractions.Repositories;
using Trackerr.Application.Abstractions.Services;

namespace Trackerr.Application.Features.Artists;

public class ArtistService : IArtistService
{
    private readonly IArtistRepository _artists;

    public ArtistService(IArtistRepository artists)
    {
        _artists = artists;
    }

    public Task<List<Artist>> GetAllAsync()
    {
        return _artists.GetAllAsync();
    }

    public Task<Artist?> GetByIdAsync(Guid id)
    {
        return _artists.GetByIdAsync(id);
    }

    public async Task<Artist> AddAsync(CreateArtistRequest request)
    {
        var artist = new Artist
        {
            Name = request.Name,
            MusicBrainzId = request.MusicBrainzId,
            Monitored = false
        };

        await _artists.AddAsync(artist);
        await _artists.SaveChangesAsync();

        return artist;
    }

    public async Task MonitorAsync(Guid id)
    {
        var artist = await _artists.GetByIdAsync(id);

        if (artist is null)
            throw new KeyNotFoundException($"Artist '{id}' not found.");

        artist.Monitored = true;

        await _artists.UpdateAsync(artist);
        await _artists.SaveChangesAsync();
    }
}