using Trackerr.Application.Features.Artists.DTOs;
using Trackerr.Core.Entities;

namespace Trackerr.Application.Abstractions.Services;

public interface IArtistService
{
    Task<List<ArtistResponse>> GetAllAsync(string? search);
    Task<ArtistDetailResponse?> GetByIdAsync(Guid id);
    Task<Result<ArtistResponse>> AddAsync(CreateArtistRequest request);
    Task<Result<ArtistResponse>> UpdateAsync(Guid id, UpdateArtistRequest request);
    Task<Result<ArtistResponse>> MonitorAsync(Guid id);
}