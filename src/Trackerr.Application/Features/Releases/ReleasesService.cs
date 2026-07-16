using Trackerr.Application.Features.Releases.DTOs;
using Trackerr.Core.Entities;
using Trackerr.Core.Abstractions.Repositories;
using Trackerr.Application.Abstractions.Services;

namespace Trackerr.Application.Features.Releases;

public class ReleaseService : IReleaseService
{
    private readonly IReleaseRepository _releases;

    public ReleaseService(IReleaseRepository release)
    {
        _releases = release;
    }

    public Task<List<Release>> GetAllAsync()
    {
        return _releases.GetAllAsync();
    }

    public Task<Release?> GetByIdAsync(Guid id)
    {
        return _releases.GetByIdAsync(id);
    }

    public async Task<Release> AddAsync(CreateReleaseRequest request)
    {
        var release = new Release
        {
            ArtistId = request.ArtistId,
            Title = request.Title,
            Type = request.Type,
            Year = request.Year,
            ReleaseDate = request.ReleaseDate,
            MusicBrainzId = request.MusicBrainzId,
            CoverArtUrl = request.CoverArtUrl,
            Monitored = request.Monitored
        };

        await _releases.AddAsync(release);
        await _releases.SaveChangesAsync();

        return release;
    }

    public async Task MonitorAsync(Guid id)
    {
        var release = await _releases.GetByIdAsync(id);

        if (release is null)
            throw new KeyNotFoundException($"Release '{id}' not found.");

        release.Monitored = true;

        await _releases.UpdateAsync(release);
        await _releases.SaveChangesAsync();
    }
}