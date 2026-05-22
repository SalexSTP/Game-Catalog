using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Domain.Enums;
using Services.DTOs;
using Services.Interfaces;
using Web.ViewModels;
using Web.ViewModels.Home;

namespace Web.Controllers;

public class HomeController : Controller
{
    private readonly IGameService gameService;

    public HomeController(IGameService gameService)
    {
        this.gameService = gameService;
    }

    public async Task<IActionResult> Index()
    {
        var games = await this.gameService.GetAllAsync(new GameQueryDto());
        
        var dashboard = new DashboardViewModel
        {
            TotalGames = games.Count,
            AverageRating = games.Any() ? games.Average(g => g.Rating) : 0,
            HighestRatedGame = games.OrderByDescending(g => g.Rating).FirstOrDefault(),
            KidFriendlyGamesCount = games.Count(g => g.PegiRating < 12),
            GenresCount = games.Select(g => g.Genre).Distinct().Count(),
            PlatformCounts = Enum.GetValues<GamePlatform>()
                .Where(platform => platform != GamePlatform.None)
                .ToDictionary(
                    platform => platform,
                    platform => games.Count(game => game.Platforms.HasFlag(platform)))
        };

        return View(dashboard);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
