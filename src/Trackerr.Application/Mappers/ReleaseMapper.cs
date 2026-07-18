using Trackerr.Application.Features.Artists.DTOs;
using Trackerr.Application.Features.Releases.DTOs;
using Trackerr.Core.Entities;

public static class ReleaseMapper
{
    // public static ReleaseResponse ToResponse(this Release release)
    // {
    //     return new ArtistResponse
    //     {
    //         Id = artist.Id,
    //         Name = artist.Name,
    //         Monitored = artist.Monitored,
    //         ReleaseCount = artist.Releases.Count,
    //         TrackCount = artist.Releases.Sum(r => r.Tracks.Count),
    //     };
    // }

    // public static ArtistDetailResponse ToDetailResponse(this Artist artist)
    // {
    //     return new ArtistDetailResponse
    //     {
    //         Id = artist.Id,
    //         Name = artist.Name,
    //         Monitored = artist.Monitored,
    //         Releases = artist.Releases.Select(r => r.ToSummaryRelease()).ToList()
    //     };
    // }

    public static ReleaseSummaryResponse ToSummaryResponse(this Release release)
    {
        return new ReleaseSummaryResponse
        {
            Id = release.Id,
            Title = release.Title,
        };
    }
}