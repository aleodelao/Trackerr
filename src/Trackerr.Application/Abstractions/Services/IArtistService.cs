using Trackerr.Application.Features.Artists.DTOs;
using Trackerr.Core.Entities;

namespace Trackerr.Application.Abstractions.Services;

public interface IArtistService
{
    Task<List<Artist>> GetAllAsync();
    Task<Artist?> GetByIdAsync(Guid id);
    Task<Artist> AddAsync(CreateArtistRequest request);
    Task MonitorAsync(Guid id);
}