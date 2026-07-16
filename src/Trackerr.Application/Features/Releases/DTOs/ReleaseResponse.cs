using Trackerr.Application.Features.Artists.DTOs;
using Trackerr.Core.Enums;

namespace Trackerr.Application.Features.Releases.DTOs;

public sealed class ReleaseResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public ReleaseType Type { get; init; }
    public int? Year { get; init; }
    public DateOnly? ReleaseDate { get; init; }
    public bool Monitored { get; init; }
    public ArtistSummaryResponse Artist { get; init; } = null!;
    public IReadOnlyCollection<TrackSummaryResponse> Tracks { get; init; } = [];
}