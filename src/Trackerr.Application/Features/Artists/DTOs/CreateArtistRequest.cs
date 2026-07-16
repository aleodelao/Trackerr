namespace Trackerr.Application.Features.Artists.DTOs;

public class CreateArtistRequest
{
    public string Name { get; set; } = string.Empty;

    public string MusicBrainzId { get; set; } = string.Empty;
}