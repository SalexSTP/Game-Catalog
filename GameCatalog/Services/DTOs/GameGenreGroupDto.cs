using Domain.Enums;

namespace Services.DTOs;

public sealed class GameGenreGroupDto
{
    public GameGenre Genre { get; set; }

    public IReadOnlyCollection<GameDto> Games { get; set; } = new List<GameDto>();
}