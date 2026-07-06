using Trackerr.Core.Enums;

namespace Trackerr.Core.Entities;

public class Release
{
    public Guid Id { get; set; }
    public string MusicBrainzId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public ReleaseType Type { get; set; }
    public int? Year { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public string? CoverArtUrl { get; set; }
    public bool Monitored { get; set; }
    public List<Track> Tracks { get; set; } = [];
}