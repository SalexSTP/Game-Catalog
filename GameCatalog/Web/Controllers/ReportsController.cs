using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Web.ViewModels.Reports;

namespace Web.Controllers;

public class ReportsController : Controller
{
    private readonly IGameService gameService;

    public ReportsController(IGameService gameService)
    {
        this.gameService = gameService;
    }

    public async Task<IActionResult> Index()
    {
        var model = new ReportsIndexViewModel
        {
            HighlyRatedGames = await this.gameService.GetHighlyRatedGamesAsync(),
            RecentPcGames = await this.gameService.GetRecentPcGamesAsync(),
            KidFriendlyGroups = await this.gameService.GetGamesForChildrenGroupedByGenreAsync(),
            TopGamesByGenre = await this.gameService.GetTopGamesByGenreAsync()
        };

        return View(model);
    }
}
