using Microsoft.Extensions.DependencyInjection;
using Trackerr.Application.Abstractions.Services;
using Trackerr.Application.Features.Artists;
using Trackerr.Application.Features.Releases;

namespace Trackerr.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IArtistService, ArtistService>();
        services.AddScoped<IReleaseService, ReleaseService>();

        return services;
    }
}