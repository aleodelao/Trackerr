
namespace Trackerr.Application.Features.Artists.DTOs;

public sealed class ArtistSummaryResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public bool Monitored { get; init; }
}