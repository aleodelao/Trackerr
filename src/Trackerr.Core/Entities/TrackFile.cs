namespace Trackerr.Core.Entities;

public class TrackFile
{
    public Guid Id { get; set; }
    public string Path { get; set; } = string.Empty;
    public long Size { get; set; }
    public string Format { get; set; } = string.Empty;
    public int Bitrate { get; set; }
    public TimeSpan Duration { get; set; }
    public Guid TrackId { get; set; }
    public Track Track { get; set; } = null!;
}