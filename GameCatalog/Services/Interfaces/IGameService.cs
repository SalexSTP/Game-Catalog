using Services.DTOs;

namespace Services.Interfaces;

public interface IGameService
{
    Task<IReadOnlyCollection<GameDto>> GetAllAsync(GameQueryDto query);

    Task<GameDto?> GetByIdAsync(Guid id);

    Task CreateAsync(GameFormDto model);

    Task UpdateAsync(Guid id, GameFormDto model);

    Task DeleteAsync(Guid id);

    Task<IReadOnlyCollection<GameDto>> GetHighlyRatedGamesAsync();

    Task<IReadOnlyCollection<GameDto>> GetRecentPcGamesAsync();

    Task<IReadOnlyCollection<GameGenreGroupDto>> GetGamesForChildrenGroupedByGenreAsync();

    Task<IReadOnlyCollection<GameGenreGroupDto>> GetTopGamesByGenreAsync();

    Task<bool> ExistsAsync(Guid id);

    Task<bool> CanCreateMoreGamesAsync();
}