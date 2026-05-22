using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Seed;

public static class GameCatalogSeeder
{
    public static async Task SeedAsync(GameCatalogDbContext context)
    {
        if (await context.Games.AnyAsync())
        {
            return;
        }

        var games = new List<Game>
        {
            new()
            {
                Title = "The Legend of Code",
                Genre = GameGenre.Adventure,
                Platforms = GamePlatform.Pc | GamePlatform.Switch,
                ReleaseYear = DateTime.UtcNow.Year,
                DeveloperStudio = "Nemetchek Game Labs",
                PegiRating = 7,
                Rating = 9.9m
            },
            new()
            {
                Title = "Elden Ring",
                Genre = GameGenre.Rpg,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox,
                ReleaseYear = 2022,
                DeveloperStudio = "FromSoftware",
                PegiRating = 16,
                Rating = 9.6m
            },
            new()
            {
                Title = "Baldur's Gate 3",
                Genre = GameGenre.Rpg,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox,
                ReleaseYear = 2023,
                DeveloperStudio = "Larian Studios",
                PegiRating = 18,
                Rating = 9.7m
            },
            new()
            {
                Title = "Hades",
                Genre = GameGenre.Action,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox | GamePlatform.Switch,
                ReleaseYear = 2020,
                DeveloperStudio = "Supergiant Games",
                PegiRating = 12,
                Rating = 9.2m
            },
            new()
            {
                Title = "Stardew Valley",
                Genre = GameGenre.Simulation,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox | GamePlatform.Switch | GamePlatform.Mobile,
                ReleaseYear = 2016,
                DeveloperStudio = "ConcernedApe",
                PegiRating = 7,
                Rating = 9.1m
            },
            new()
            {
                Title = "Minecraft",
                Genre = GameGenre.Simulation,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox | GamePlatform.Switch | GamePlatform.Mobile,
                ReleaseYear = 2011,
                DeveloperStudio = "Mojang Studios",
                PegiRating = 7,
                Rating = 8.9m
            },
            new()
            {
                Title = "Portal 2",
                Genre = GameGenre.Puzzle,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox | GamePlatform.Switch,
                ReleaseYear = 2011,
                DeveloperStudio = "Valve",
                PegiRating = 12,
                Rating = 9.4m
            },
            new()
            {
                Title = "Forza Horizon 5",
                Genre = GameGenre.Sports,
                Platforms = GamePlatform.Pc | GamePlatform.Xbox,
                ReleaseYear = 2021,
                DeveloperStudio = "Playground Games",
                PegiRating = 3,
                Rating = 8.8m
            },
            new()
            {
                Title = "FIFA 23",
                Genre = GameGenre.Sports,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox | GamePlatform.Switch,
                ReleaseYear = 2022,
                DeveloperStudio = "EA Vancouver",
                PegiRating = 3,
                Rating = 7.6m
            },
            new()
            {
                Title = "Civilization VI",
                Genre = GameGenre.Strategy,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox | GamePlatform.Switch | GamePlatform.Mobile,
                ReleaseYear = 2016,
                DeveloperStudio = "Firaxis Games",
                PegiRating = 12,
                Rating = 8.7m
            },
            new()
            {
                Title = "Age of Empires IV",
                Genre = GameGenre.Strategy,
                Platforms = GamePlatform.Pc | GamePlatform.Xbox,
                ReleaseYear = 2021,
                DeveloperStudio = "Relic Entertainment",
                PegiRating = 12,
                Rating = 8.3m
            },
            new()
            {
                Title = "Into the Breach",
                Genre = GameGenre.Strategy,
                Platforms = GamePlatform.Pc | GamePlatform.Switch | GamePlatform.Mobile,
                ReleaseYear = 2018,
                DeveloperStudio = "Subset Games",
                PegiRating = 7,
                Rating = 8.6m
            },
            new()
            {
                Title = "Celeste",
                Genre = GameGenre.Indie,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox | GamePlatform.Switch,
                ReleaseYear = 2018,
                DeveloperStudio = "Maddy Makes Games",
                PegiRating = 7,
                Rating = 9.0m
            },
            new()
            {
                Title = "Hollow Knight",
                Genre = GameGenre.Indie,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox | GamePlatform.Switch,
                ReleaseYear = 2017,
                DeveloperStudio = "Team Cherry",
                PegiRating = 7,
                Rating = 9.3m
            },
            new()
            {
                Title = "Cuphead",
                Genre = GameGenre.Indie,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox | GamePlatform.Switch,
                ReleaseYear = 2017,
                DeveloperStudio = "Studio MDHR",
                PegiRating = 7,
                Rating = 8.7m
            },
            new()
            {
                Title = "Doom Eternal",
                Genre = GameGenre.Shooter,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox | GamePlatform.Switch,
                ReleaseYear = 2020,
                DeveloperStudio = "id Software",
                PegiRating = 18,
                Rating = 8.9m
            },
            new()
            {
                Title = "Overwatch 2",
                Genre = GameGenre.Shooter,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox | GamePlatform.Switch,
                ReleaseYear = 2022,
                DeveloperStudio = "Blizzard Entertainment",
                PegiRating = 12,
                Rating = 7.3m
            },
            new()
            {
                Title = "Animal Crossing: New Horizons",
                Genre = GameGenre.Simulation,
                Platforms = GamePlatform.Switch,
                ReleaseYear = 2020,
                DeveloperStudio = "Nintendo",
                PegiRating = 3,
                Rating = 8.5m
            },
            new()
            {
                Title = "Rocket League",
                Genre = GameGenre.Sports,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox | GamePlatform.Switch,
                ReleaseYear = 2015,
                DeveloperStudio = "Psyonix",
                PegiRating = 3,
                Rating = 8.4m
            },
            new()
            {
                Title = "Cities: Skylines II",
                Genre = GameGenre.Simulation,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox,
                ReleaseYear = 2023,
                DeveloperStudio = "Colossal Order",
                PegiRating = 3,
                Rating = 7.0m
            },
            new()
            {
                Title = "Sea of Stars",
                Genre = GameGenre.Rpg,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox | GamePlatform.Switch,
                ReleaseYear = 2023,
                DeveloperStudio = "Sabotage Studio",
                PegiRating = 7,
                Rating = 8.6m
            },
            new()
            {
                Title = "Hi-Fi Rush",
                Genre = GameGenre.Action,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox,
                ReleaseYear = 2023,
                DeveloperStudio = "Tango Gameworks",
                PegiRating = 12,
                Rating = 8.8m
            },
            new()
            {
                Title = "Super Mario Bros. Wonder",
                Genre = GameGenre.Adventure,
                Platforms = GamePlatform.Switch,
                ReleaseYear = 2023,
                DeveloperStudio = "Nintendo",
                PegiRating = 3,
                Rating = 9.0m
            },
            new()
            {
                Title = "Marvel's Spider-Man 2",
                Genre = GameGenre.Action,
                Platforms = GamePlatform.PlayStation,
                ReleaseYear = 2023,
                DeveloperStudio = "Insomniac Games",
                PegiRating = 16,
                Rating = 8.7m
            },
            new()
            {
                Title = "Balatro",
                Genre = GameGenre.Puzzle,
                Platforms = GamePlatform.Pc | GamePlatform.PlayStation | GamePlatform.Xbox | GamePlatform.Switch | GamePlatform.Mobile,
                ReleaseYear = 2024,
                DeveloperStudio = "LocalThunk",
                PegiRating = 18,
                Rating = 8.9m
            }
        };

        await context.Games.AddRangeAsync(games);
        await context.SaveChangesAsync();
    }
}
