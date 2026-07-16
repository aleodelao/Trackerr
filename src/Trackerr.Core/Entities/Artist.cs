namespace Trackerr.Core.Entities;

public class Artist
{
    public Guid Id { get; set; }
    public string? MusicBrainzId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Monitored { get; set; }
    public List<Release> Releases { get; set; } = [];

}