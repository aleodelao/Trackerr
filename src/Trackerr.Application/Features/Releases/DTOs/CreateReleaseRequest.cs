using Trackerr.Core.Enums;

namespace Trackerr.Application.Features.Releases.DTOs;

public class CreateReleaseRequest
{
    public Guid ArtistId { get; init; }
    public string Title { get; init; } = string.Empty;
    public ReleaseType Type { get; init; }
    public int? Year { get; init; }
    public DateOnly? ReleaseDate { get; init; }
    public string? MusicBrainzId { get; init; }
    public string? CoverArtUrl { get; init; }
    public bool Monitored { get; init; } = true;
}