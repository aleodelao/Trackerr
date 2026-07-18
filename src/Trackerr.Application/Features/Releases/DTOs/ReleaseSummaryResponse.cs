using Trackerr.Core.Enums;

namespace Trackerr.Application.Features.Releases.DTOs;

public sealed class ReleaseSummaryResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
}