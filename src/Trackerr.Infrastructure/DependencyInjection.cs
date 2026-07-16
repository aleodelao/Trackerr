using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trackerr.Core.Abstractions.Repositories;
using Trackerr.Infrastructure.Persistence;
using Trackerr.Infrastructure.Persistence.Repositories;

namespace Trackerr.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var dbPath = configuration["Database:Path"]!;

        if (dbPath.StartsWith("~/"))
        {
            var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            dbPath = Path.Combine(home, dbPath[2..]);
        }

        services.AddDbContext<TrackerrDbContext>(options =>
        {
            options.UseSqlite($"Data Source={dbPath}");
        });

        services.AddScoped<IArtistRepository, ArtistRepository>();
        services.AddScoped<IReleaseRepository, ReleaseRepository>();
        // services.AddScoped<ITrackRepository, TrackRepository>();
        // services.AddScoped<ITrackFileRepository, TrackFileRepository>();
        // services.AddScoped<ILibraryRootRepository, LibraryRootRepository>();

        return services;
    }
}