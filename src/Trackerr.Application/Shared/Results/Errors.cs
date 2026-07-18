namespace Trackerr.Application.Shared.Results;

public static class Errors
{
    public static class Artist
    {
        public static readonly Error NotFound = 
            new(
                "Artist.NotFound",
                "The requested artist was not found.",
                ErrorType.NotFound
            );

        public static readonly Error AlreadyExists = 
            new(
                "Artist.AlreadyExists",
                "An artist with this MusicBrainz ID already exists.",
                ErrorType.Conflict
            );
    }
}