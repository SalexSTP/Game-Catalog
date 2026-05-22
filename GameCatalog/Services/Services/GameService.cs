using Data.Repositories;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Services.DTOs;
using Services.Enums;
using Services.Interfaces;
using static Common.Constants.GameConstants;

namespace Services.Implementations;

public sealed class GameService : IGameService
{
    private readonly IRepository<Game> gameRepository;

    public GameService(IRepository<Game> gameRepository)
    {
        this.gameRepository = gameRepository;
    }

    public async Task<IReadOnlyCollection<GameDto>> GetAllAsync(GameQueryDto query)
    {
        IQueryable<Game> gamesQuery = this.gameRepository.AllAsNoTracking();

        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            string searchTermLower = query.SearchTerm.ToLower();
            gamesQuery = gamesQuery.Where(g => 
                g.Title.ToLower().Contains(searchTermLower) || 
                g.DeveloperStudio.ToLower().Contains(searchTermLower));
        }

        if (query.Genre.HasValue)
        {
            gamesQuery = gamesQuery.Where(g => g.Genre == query.Genre.Value);
        }

        if (query.Platform.HasValue)
        {
            gamesQuery = gamesQuery.Where(g => g.Platforms.HasFlag(query.Platform.Value));
        }

        if (query.MaxPegiRating.HasValue)
        {
            gamesQuery = gamesQuery.Where(g => g.PegiRating <= query.MaxPegiRating.Value);
        }

        if (query.MinRating.HasValue)
        {
            gamesQuery = gamesQuery.Where(g => g.Rating >= query.MinRating.Value);
        }

        gamesQuery = ApplySorting(gamesQuery, query.SortCriteria);

        return await gamesQuery
            .Select(g => ToGameDto(g))
            .ToListAsync();
    }

    public async Task<GameDto?> GetByIdAsync(Guid id)
    {
        return await this.gameRepository
            .AllAsNoTracking()
            .Where(g => g.Id == id)
            .Select(g => ToGameDto(g))
            .FirstOrDefaultAsync();
    }

    public async Task CreateAsync(GameFormDto model)
    {
        bool canCreateMoreGames = await this.CanCreateMoreGamesAsync();

        if (!canCreateMoreGames)
        {
            throw new InvalidOperationException($"The catalog cannot contain more than {MaxGamesCount} games.");
        }

        Game game = new()
        {
            Title = model.Title.Trim(),
            Genre = model.Genre,
            Platforms = model.Platforms,
            ReleaseYear = model.ReleaseYear,
            DeveloperStudio = model.DeveloperStudio.Trim(),
            PegiRating = model.PegiRating,
            Rating = model.Rating
        };

        await this.gameRepository.AddAsync(game);
        await this.gameRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, GameFormDto model)
    {
        Game? game = await this.gameRepository.GetByIdAsync(id);

        if (game is null)
        {
            throw new InvalidOperationException("Game not found.");
        }

        game.Title = model.Title.Trim();
        game.Genre = model.Genre;
        game.Platforms = model.Platforms;
        game.ReleaseYear = model.ReleaseYear;
        game.DeveloperStudio = model.DeveloperStudio.Trim();
        game.PegiRating = model.PegiRating;
        game.Rating = model.Rating;

        this.gameRepository.Update(game);
        await this.gameRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        Game? game = await this.gameRepository.GetByIdAsync(id);

        if (game is null)
        {
            throw new InvalidOperationException("Game not found.");
        }

        this.gameRepository.Delete(game);
        await this.gameRepository.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<GameDto>> GetHighlyRatedGamesAsync()
    {
        return await this.gameRepository
            .AllAsNoTracking()
            .Where(g => g.Rating > ExcellentRatingThreshold)
            .OrderByDescending(g => g.Title == FeaturedTitle)
            .ThenByDescending(g => g.ReleaseYear)
            .ThenBy(g => g.Title)
            .Select(g => ToGameDto(g))
            .ToListAsync();
    }

    public async Task<IReadOnlyCollection<GameDto>> GetRecentPcGamesAsync()
    {
        int fromYear = DateTime.UtcNow.Year - RecentYearsRange;

        return await this.gameRepository
            .AllAsNoTracking()
            .Where(g => (g.Platforms & GamePlatform.Pc) == GamePlatform.Pc)
            .Where(g => g.ReleaseYear >= fromYear)
            .OrderByDescending(g => g.Title == FeaturedTitle)
            .ThenByDescending(g => g.Rating)
            .ThenBy(g => g.Title)
            .Select(g => ToGameDto(g))
            .ToListAsync();
    }

    public async Task<IReadOnlyCollection<GameGenreGroupDto>> GetGamesForChildrenGroupedByGenreAsync()
    {
        List<GameDto> games = await this.gameRepository
            .AllAsNoTracking()
            .Where(g => g.PegiRating < PegiUnderAgeLimit)
            .OrderBy(g => g.Genre)
            .ThenByDescending(g => g.Title == FeaturedTitle)
            .ThenBy(g => g.Title)
            .Select(g => ToGameDto(g))
            .ToListAsync();

        return games
            .GroupBy(g => g.Genre)
            .Select(group => new GameGenreGroupDto
            {
                Genre = group.Key,
                Games = group.ToList()
            })
            .ToList();
    }

    public async Task<IReadOnlyCollection<GameGenreGroupDto>> GetTopGamesByGenreAsync()
    {
        List<GameDto> games = await this.gameRepository
            .AllAsNoTracking()
            .OrderBy(g => g.Genre)
            .ThenByDescending(g => g.Title == FeaturedTitle)
            .ThenByDescending(g => g.Rating)
            .ThenBy(g => g.Title)
            .Select(g => ToGameDto(g))
            .ToListAsync();

        return games
            .GroupBy(g => g.Genre)
            .Select(group => new GameGenreGroupDto
            {
                Genre = group.Key,
                Games = group
                    .Take(TopGamesPerGenre)
                    .ToList()
            })
            .ToList();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await this.gameRepository
            .AllAsNoTracking()
            .AnyAsync(g => g.Id == id);
    }

    public async Task<bool> CanCreateMoreGamesAsync()
    {
        int currentGamesCount = await this.gameRepository
            .AllAsNoTracking()
            .CountAsync();

        return currentGamesCount < MaxGamesCount;
    }

    private static IQueryable<Game> ApplySorting(
        IQueryable<Game> query,
        IReadOnlyCollection<GameSortCriterionDto>? sortCriteria)
    {
        IOrderedQueryable<Game> orderedQuery = query
            .OrderByDescending(g => g.Title == FeaturedTitle);

        if (sortCriteria is null || sortCriteria.Count == 0)
        {
            return orderedQuery.ThenBy(g => g.Title);
        }

        foreach (GameSortCriterionDto criterion in sortCriteria)
        {
            orderedQuery = ApplyThenSorting(orderedQuery, criterion);
        }

        return orderedQuery;
    }

    private static IOrderedQueryable<Game> ApplyThenSorting(
        IOrderedQueryable<Game> query,
        GameSortCriterionDto criterion)
    {
        bool descending = criterion.Direction == SortDirection.Descending;

        return criterion.Field switch
        {
            GameSortField.Title => descending
                ? query.ThenByDescending(g => g.Title)
                : query.ThenBy(g => g.Title),

            GameSortField.ReleaseYear => descending
                ? query.ThenByDescending(g => g.ReleaseYear)
                : query.ThenBy(g => g.ReleaseYear),

            GameSortField.Genre => descending
                ? query.ThenByDescending(g => g.Genre)
                : query.ThenBy(g => g.Genre),

            GameSortField.Rating => descending
                ? query.ThenByDescending(g => g.Rating)
                : query.ThenBy(g => g.Rating),

            GameSortField.DeveloperStudio => descending
                ? query.ThenByDescending(g => g.DeveloperStudio)
                : query.ThenBy(g => g.DeveloperStudio),

            _ => query.ThenBy(g => g.Title)
        };
    }

    private static GameDto ToGameDto(Game game)
    {
        return new GameDto
        {
            Id = game.Id,
            Title = game.Title,
            Genre = game.Genre,
            Platforms = game.Platforms,
            ReleaseYear = game.ReleaseYear,
            DeveloperStudio = game.DeveloperStudio,
            PegiRating = game.PegiRating,
            Rating = game.Rating
        };
    }
}