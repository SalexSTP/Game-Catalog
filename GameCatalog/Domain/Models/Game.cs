using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using static Common.Constants.GameConstants;

namespace Domain.Models;

public sealed class Game
{
    public Guid Id { get; private set; }

    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; } = null!;

    public GameGenre Genre { get; set; }

    public GamePlatform Platforms { get; set; }

    [Range(MinReleaseYear, MaxReleaseYear)]
    public int ReleaseYear { get; set; }

    [Required]
    [MaxLength(DeveloperStudioMaxLength)]
    public string DeveloperStudio { get; set; } = null!;

    [Range(MinPegiAge, MaxPegiAge)]
    public int PegiRating { get; set; }

    [Range(typeof(decimal), "1.0", "10.0")]
    public decimal Rating { get; set; }
}