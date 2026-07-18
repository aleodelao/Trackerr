namespace Trackerr.Application.Shared.Results;

public enum ErrorType
{
    NotFound,
    Validation,
    Conflict,
    ExternalService,
    Unauthorized,
    Unexpected
}