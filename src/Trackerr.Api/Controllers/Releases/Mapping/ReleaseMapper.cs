

using Trackerr.Application.Features.Artists.DTOs;
using Trackerr.Application.Features.Releases.DTOs;
using Trackerr.Core.Entities;

public static class ReleaseMapper
{
    public static ReleaseResponse ToResponse(this Release release)
    {
        return new ReleaseResponse
        {
            Id = release.Id,
            Title = release.Title,
            Type = release.Type,
            Year = release.Year,
            ReleaseDate = release.ReleaseDate,
            Monitored = release.Monitored,

            Artist = new ArtistSummaryResponse
            {
                Id = release.Artist.Id,
                Name = release.Artist.Name
            },
            
            Tracks = release.Tracks
                .OrderBy(t => t.DiscNumber)
                .ThenBy(t => t.TrackNumber)
                .Select(t => new TrackSummaryResponse
                {
                    Id = t.Id,
                    MusicBrainzId = t.MusicBrainzId,
                    Title = t.Title,
                    DiscNumber = t.DiscNumber,
                    TrackNumber = t.TrackNumber,
                    Duration = t.Duration,
                    Status = t.Status
                })
                .ToList()

        };
    }
}