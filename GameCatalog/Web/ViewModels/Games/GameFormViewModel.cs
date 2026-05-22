using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using static Common.Constants.GameConstants;

namespace Web.ViewModels.Games;

public class GameFormViewModel : IValidatableObject
{
    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(TitleMaxLength, ErrorMessage = "Title cannot be longer than {1} characters.")]
    [Display(Name = "Title")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Genre is required.")]
    [Display(Name = "Genre")]
    public GameGenre Genre { get; set; }

    public GamePlatform Platforms { get; set; }

    [Display(Name = "Platforms")]
    public List<GamePlatform> SelectedPlatforms { get; set; } = new();

    [Range(MinReleaseYear, MaxReleaseYear, ErrorMessage = "Release year must be between {1} and {2}.")]
    [Display(Name = "Release Year")]
    public int ReleaseYear { get; set; } = DateTime.UtcNow.Year;

    [Required(ErrorMessage = "Developer studio is required.")]
    [MaxLength(DeveloperStudioMaxLength, ErrorMessage = "Developer studio cannot be longer than {1} characters.")]
    [Display(Name = "Developer Studio")]
    public string DeveloperStudio { get; set; } = null!;

    [Range(MinPegiAge, MaxPegiAge, ErrorMessage = "PEGI rating must be between {1} and {2}.")]
    [Display(Name = "PEGI Rating")]
    public int PegiRating { get; set; } = PegiUnderAgeLimit;

    [Range(typeof(decimal), "1.0", "10.0", ErrorMessage = "Rating must be between 1.0 and 10.0.")]
    [Display(Name = "User Rating")]
    public decimal Rating { get; set; } = MinRating;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (SelectedPlatforms is null || SelectedPlatforms.Count == 0)
        {
            yield return new ValidationResult(
                "Select at least one platform.",
                new[] { nameof(SelectedPlatforms) });
        }
    }
}
