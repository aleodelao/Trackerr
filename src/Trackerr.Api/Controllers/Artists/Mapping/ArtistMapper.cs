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
            MusicBrainzId = artist.MusicBrainzId,
            Name = artist.Name,
            Monitored = artist.Monitored,

            Releases = artist.Releases
                .Select(x => new ReleaseSummaryResponse
                {
                    Id = x.Id,
                    Title = x.Title,
                    Type = x.Type,
                    Year = x.Year,
                    Monitored = x.Monitored
                })
                .ToList()
        };
    }
}