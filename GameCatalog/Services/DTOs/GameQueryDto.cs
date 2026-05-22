namespace Services.DTOs;

public sealed class GameQueryDto
{
    public IReadOnlyCollection<GameSortCriterionDto> SortCriteria { get; set; }
        = new List<GameSortCriterionDto>();
}