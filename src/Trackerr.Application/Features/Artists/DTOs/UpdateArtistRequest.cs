namespace Trackerr.Application.Features.Artists.DTOs;

public class UpdateArtistRequest
{
    public string Name { get; set; } = string.Empty;
    public bool Monitored { get; set; } = true;
}