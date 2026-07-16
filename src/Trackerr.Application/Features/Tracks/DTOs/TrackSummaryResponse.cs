using Trackerr.Core.Enums;

public sealed class TrackSummaryResponse
{
    public Guid Id { get; init; }

    public string? MusicBrainzId { get; init; }

    public string Title { get; init; }
        = string.Empty;

    public int DiscNumber { get; init; }

    public int TrackNumber { get; init; }

    public TimeSpan Duration { get; init; }

    public TrackStatus Status { get; init; }
}