using Trackerr.Application.Features.Releases.DTOs;

namespace Trackerr.Application.Features.Artists.DTOs;

public sealed class ArtistResponse
{
    public Guid Id { get; init; }
    public string? MusicBrainzId { get; init; }
    public string Name { get; init; } = string.Empty;
    public bool Monitored { get; init; }
    public IReadOnlyCollection<ReleaseSummaryResponse> Releases { get; init; } = [];
}