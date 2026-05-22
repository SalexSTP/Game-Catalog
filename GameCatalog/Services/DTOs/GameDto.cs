using Domain.Enums;

namespace Services.DTOs;

public sealed class GameDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public GameGenre Genre { get; set; }

    public GamePlatform Platforms { get; set; }

    public int ReleaseYear { get; set; }

    public string DeveloperStudio { get; set; } = null!;

    public int PegiRating { get; set; }

    public decimal Rating { get; set; }
}