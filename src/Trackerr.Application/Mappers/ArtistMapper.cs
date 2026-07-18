using Trackerr.Application.Features.Artists.DTOs;
using Trackerr.Application.Features.Releases.DTOs;
using Trackerr.Core.Entities;

public static class ArtistMapper
{
    public static ArtistResponse ToResponse(this Artist artist)
    {
        return new ArtistResponse
        {
            Id = artist.Id,
            Name = artist.Name,
            Monitored = artist.Monitored,
            ReleaseCount = artist.Releases.Count,
            TrackCount = artist.Releases.Sum(r => r.Tracks.Count),
        };
    }

    public static ArtistDetailResponse ToDetailResponse(this Artist artist)
    {
        return new ArtistDetailResponse
        {
            Id = artist.Id,
            Name = artist.Name,
            Monitored = artist.Monitored,
            Releases = artist.Releases.Select(r => r.ToSummaryResponse()).ToList()
        };
    }
}