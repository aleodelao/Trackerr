using Trackerr.Core.Enums;

namespace Trackerr.Core.Entities;

public class Track
{
    public Guid Id { get; set; }
    public string? MusicBrainzId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int TrackNumber { get; set; }
    public int DiscNumber { get; set; }
    public TimeSpan Duration { get; set; }
    public bool Monitored { get; set; }
    public TrackStatus Status { get; set; }
    public Guid ReleaseId { get; set; }
    public Release Release { get; set; } = null!;
    public List<TrackFile> Files { get; set; } = [];
}