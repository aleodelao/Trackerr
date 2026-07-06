namespace Trackerr.Core.Entities;

public class Artist
{
    public Guid Id { get; set; }
    public string MusicBrainzId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<Release> Releases { get; set; } = [];
}