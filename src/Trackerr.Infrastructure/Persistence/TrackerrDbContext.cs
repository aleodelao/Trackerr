using System.Numerics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trackerr.Core.Entities;

namespace Trackerr.Infrastructure.Persistence;

public class TrackerrDbContext(DbContextOptions<TrackerrDbContext> options) : DbContext(options)
{
    public DbSet<Artist> Artists => Set<Artist>();
    public DbSet<Release> Releases => Set<Release>();
    public DbSet<Track> Tracks => Set<Track>();
    public DbSet<TrackFile> TrackFiles => Set<TrackFile>();
    public DbSet<LibraryRoot> LibraryRoots => Set<LibraryRoot>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureArtist(modelBuilder);
        ConfigureRelease(modelBuilder);
        ConfigureTrack(modelBuilder);
        ConfigureTrackFile(modelBuilder);
        ConfigureLibraryRoot(modelBuilder);
    }

    private static void ConfigureArtist(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>(builder =>
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.MusicBrainzId)
                .HasMaxLength(36);

            builder.HasIndex(x => x.MusicBrainzId)
                .IsUnique();
            
            builder.HasIndex(x => x.Name);

            builder.HasMany(x => x.Releases)
                .WithOne(x => x.Artist)
                .HasForeignKey(x => x.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigureRelease(ModelBuilder modelBuilder)
    {
        var dateConverter = new ValueConverter<DateOnly?, DateTime?>(
            d => d.HasValue
                ? d.Value.ToDateTime(TimeOnly.MinValue)
                : null,
            d => d.HasValue
                ? DateOnly.FromDateTime(d.Value)
                : null);

        modelBuilder.Entity<Release>(builder =>
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.MusicBrainzId)
                .HasMaxLength(36);

            builder.Property(x => x.ReleaseDate)
                .HasConversion(dateConverter);

            builder.Property(x => x.CoverArtUrl)
                .HasMaxLength(1024);

            builder.HasIndex(x => x.MusicBrainzId)
                .IsUnique();
            
            builder.HasIndex(x => new { x.ArtistId, x.Title });

            builder.HasMany(x => x.Tracks)
                .WithOne(x => x.Release)
                .HasForeignKey(x => x.ReleaseId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigureTrack(ModelBuilder modelBuilder)
    {
        var timeSpanConverter = new ValueConverter<TimeSpan, long>(
            v => v.Ticks,
            v => TimeSpan.FromTicks(v));

        modelBuilder.Entity<Track>(builder =>
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.MusicBrainzId)
                .HasMaxLength(36);

            builder.Property(x => x.Duration)
                .HasConversion(timeSpanConverter);

            builder.HasIndex(x => x.MusicBrainzId)
                .IsUnique();
            
            builder.HasIndex(x => new { x.ReleaseId, x.DiscNumber, x.TrackNumber });

            builder.HasMany(x => x.Files)
                .WithOne(x => x.Track)
                .HasForeignKey(x => x.TrackId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigureTrackFile(ModelBuilder modelBuilder)
    {
        var timeSpanConverter = new ValueConverter<TimeSpan, long>(
            v => v.Ticks,
            v => TimeSpan.FromTicks(v));

        modelBuilder.Entity<TrackFile>(builder =>
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Path)
                .HasMaxLength(2048)
                .IsRequired();

            builder.Property(x => x.Format)
                .HasMaxLength(32);

            builder.Property(x => x.Codec)
                .HasMaxLength(64);

            builder.Property(x => x.Duration)
                .HasConversion(timeSpanConverter);

            builder.Property(x => x.Hash)
                .HasColumnType("BLOB");

            builder.HasIndex(x => x.Path)
                .IsUnique();
            
            builder.HasIndex(x => x.Hash);
            
            builder.HasIndex(x => x.TrackId);
        });
    }

    private static void ConfigureLibraryRoot(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LibraryRoot>(builder =>
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(x => x.Path)
                .HasMaxLength(2048)
                .IsRequired();

            builder.HasIndex(x => x.Path)
                .IsUnique();
            
            builder.HasIndex(x => x.Name);
            
            builder.HasMany(x => x.TrackFiles)
                .WithOne(x => x.LibraryRoot)
                .HasForeignKey(x => x.LibraryRootId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}