using Trackerr.Application.Features.Releases.DTOs;
using Trackerr.Core.Entities;

namespace Trackerr.Application.Abstractions.Services;

public interface IReleaseService
{
    Task<List<Release>> GetAllAsync();
    Task<Release?> GetByIdAsync(Guid id);
    Task<Release> AddAsync(CreateReleaseRequest request);
    Task MonitorAsync(Guid id);
}