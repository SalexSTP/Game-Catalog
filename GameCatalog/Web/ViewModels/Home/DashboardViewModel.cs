using Domain.Enums;
using Services.DTOs;

namespace Web.ViewModels.Home;

public class DashboardViewModel
{
    public int TotalGames { get; set; }

    public decimal AverageRating { get; set; }

    public GameDto? HighestRatedGame { get; set; }

    public int KidFriendlyGamesCount { get; set; }

    public int GenresCount { get; set; }

    public IReadOnlyDictionary<GamePlatform, int> PlatformCounts { get; set; }
        = new Dictionary<GamePlatform, int>();
}
