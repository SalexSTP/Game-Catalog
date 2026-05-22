using Domain.Models;
using Microsoft.EntityFrameworkCore;
using static Common.Constants.GameConstants;

namespace Data;

public sealed class GameCatalogDbContext(DbContextOptions<GameCatalogDbContext> options)
    : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(g => g.Id);

            entity.Property(g => g.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            entity.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            entity.Property(g => g.Genre)
                .HasConversion<int>()
                .IsRequired();

            entity.Property(g => g.Platforms)
                .HasConversion<int>()
                .IsRequired();

            entity.Property(g => g.ReleaseYear)
                .IsRequired();

            entity.Property(g => g.DeveloperStudio)
                .IsRequired()
                .HasMaxLength(DeveloperStudioMaxLength);

            entity.Property(g => g.PegiRating)
                .IsRequired();

            entity.Property(g => g.Rating)
                .HasPrecision(3, 1)
                .IsRequired();
        });
    }
}