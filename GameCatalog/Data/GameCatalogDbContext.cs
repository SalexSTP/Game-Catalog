using Microsoft.EntityFrameworkCore;

namespace Data;

public sealed class GameCatalogDbContext(DbContextOptions<GameCatalogDbContext> options)
    : DbContext(options)
{
}