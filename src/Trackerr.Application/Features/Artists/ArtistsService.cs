using Trackerr.Application.Features.Artists.DTOs;
using Trackerr.Core.Entities;
using Trackerr.Core.Abstractions.Repositories;
using Trackerr.Application.Abstractions.Services;
using Trackerr.Application.Shared.Results;

namespace Trackerr.Application.Features.Artists;

public class ArtistService(IArtistRepository artistsRepository) : IArtistService
{
    private readonly IArtistRepository _artistsRepository = artistsRepository;

    public async Task<List<ArtistResponse>> GetAllAsync(string? search)
    {
        var artists = await _artistsRepository.GetAllAsync(search);

        return artists.Select(a => a.ToResponse()).ToList();
    }

    public async Task<ArtistDetailResponse?> GetByIdAsync(Guid id)
    {
        var artist = await _artistsRepository.GetByIdAsync(id);

        return artist?.ToDetailResponse();
    }

    public async Task<Result<ArtistResponse>> AddAsync(CreateArtistRequest request)
    {
        var artist = new Artist
        {
            Name = request.Name,
            MusicBrainzId = request.MusicBrainzId,
            Monitored = false
        };

        await _artistsRepository.AddAsync(artist);
        await _artistsRepository.SaveChangesAsync();

        return Result<ArtistResponse>.Success(artist.ToResponse());
    }

    public async Task<Result<ArtistResponse>> UpdateAsync(Guid id, UpdateArtistRequest request)
    {
        var artist = await _artistsRepository.GetByIdAsync(id);

        if (artist is null)
            return Result<ArtistResponse>.Failure(Errors.Artist.NotFound);

        artist.Name = request.Name;
        artist.Monitored = request.Monitored;

        await _artistsRepository.UpdateAsync(artist);
        await _artistsRepository.SaveChangesAsync();

        return Result<ArtistResponse>.Success(artist.ToResponse());
    }

    public async Task<Result<ArtistResponse>> MonitorAsync(Guid id)
    {
        var artist = await _artistsRepository.GetByIdAsync(id);

        if (artist is null)
            return Result<ArtistResponse>.Failure(Errors.Artist.NotFound);

        artist.Monitored = true;

        await _artistsRepository.UpdateAsync(artist);
        await _artistsRepository.SaveChangesAsync();

        return Result<ArtistResponse>.Success(artist.ToResponse());
    }
}