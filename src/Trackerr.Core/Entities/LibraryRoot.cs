using Trackerr.Core.Enums;

namespace Trackerr.Core.Entities;

public class LibraryRoot
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
    public DateTime? LastScannedUtd { get; set; }
    public List<TrackFile> TrackFiles { get; set; } = [];
}