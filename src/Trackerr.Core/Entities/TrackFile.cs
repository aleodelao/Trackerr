namespace Trackerr.Core.Entities;

public class TrackFile
{
    public Guid Id { get; set; }
    public string Path { get; set; } = string.Empty;
    public long Size { get; set; }
    public TimeSpan Duration { get; set; }
    public string Format { get; set; } = string.Empty;
    public string Codec { get; set; } = string.Empty;
    public int Bitrate { get; set; }
    public int SampleRate { get; set; }
    public byte[]? Hash { get; set; }
    public DateTime LastModifiedUtc { get; set; }
    public Guid TrackId { get; set; }
    public Track Track { get; set; } = null!;
    public Guid LibraryRootId { get; set; }
    public LibraryRoot LibraryRoot { get; set; } = null!;
}