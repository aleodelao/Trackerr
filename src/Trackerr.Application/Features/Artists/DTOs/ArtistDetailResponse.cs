using Trackerr.Application.Features.Releases.DTOs;

namespace Trackerr.Application.Features.Artists.DTOs;

public sealed class ArtistDetailResponse
{
    public Guid Id { get; init; }
    public string? MusicBrainzId { get; init; }
    public string Name { get; init; } = string.Empty;
    public bool Monitored { get; init; }
    public List<ReleaseSummaryResponse> Releases { get; init; } = [];
}