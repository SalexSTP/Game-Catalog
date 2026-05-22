using Domain.Enums;

namespace Services.DTOs;

public sealed class GameQueryDto
{
    public string? SearchTerm { get; set; }

    public GameGenre? Genre { get; set; }

    public GamePlatform? Platform { get; set; }

    public int? MaxPegiRating { get; set; }

    public decimal? MinRating { get; set; }

    public IReadOnlyCollection<GameSortCriterionDto> SortCriteria { get; set; }
        = new List<GameSortCriterionDto>();
}