using Services.Enums;

namespace Services.DTOs;

public sealed class GameSortCriterionDto
{
    public GameSortField Field { get; set; }

    public SortDirection Direction { get; set; }
}