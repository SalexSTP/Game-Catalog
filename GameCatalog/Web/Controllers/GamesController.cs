using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.DTOs;
using Services.Interfaces;
using Web.ViewModels.Games;
using Domain.Enums;
using Services.Enums;
using Web.Localization;

namespace Web.Controllers;

public class GamesController : Controller
{
    private readonly IGameService gameService;

    public GamesController(IGameService gameService)
    {
        this.gameService = gameService;
    }

    public async Task<IActionResult> Index(GameIndexViewModel model)
    {
        var criteria = new List<GameSortCriterionDto>();

        if (!string.IsNullOrEmpty(model.SortField1) && Enum.TryParse<GameSortField>(model.SortField1, out var field1))
            criteria.Add(new GameSortCriterionDto { Field = field1, Direction = model.SortDescending1 ? SortDirection.Descending : SortDirection.Ascending });
            
        if (!string.IsNullOrEmpty(model.SortField2) && Enum.TryParse<GameSortField>(model.SortField2, out var field2))
            criteria.Add(new GameSortCriterionDto { Field = field2, Direction = model.SortDescending2 ? SortDirection.Descending : SortDirection.Ascending });
            
        if (!string.IsNullOrEmpty(model.SortField3) && Enum.TryParse<GameSortField>(model.SortField3, out var field3))
            criteria.Add(new GameSortCriterionDto { Field = field3, Direction = model.SortDescending3 ? SortDirection.Descending : SortDirection.Ascending });

        var query = new GameQueryDto
        {
            SearchTerm = model.SearchTerm,
            Genre = model.Genre,
            Platform = model.Platform,
            MaxPegiRating = model.MaxPegiRating,
            MinRating = model.MinRating,
            SortCriteria = criteria
        };

        model.Games = await this.gameService.GetAllAsync(query);

        var availableGenres = Enum.GetValues<GameGenre>()
            .Select(genre => new { Id = genre, Name = UiText.Genre(HttpContext, genre) });
        model.Genres = new SelectList(availableGenres, "Id", "Name");

        var availablePlatforms = Enum.GetValues<GamePlatform>()
            .Where(platform => platform != GamePlatform.None)
            .Select(platform => new { Id = platform, Name = UiText.Platform(HttpContext, platform) });
        model.Platforms = new SelectList(availablePlatforms, "Id", "Name");

        return View(model);
    }

    public IActionResult Create()
    {
        return View(new GameFormViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(GameFormViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        bool canCreate = await this.gameService.CanCreateMoreGamesAsync();
        if (!canCreate)
        {
            ModelState.AddModelError("", UiText.GetLanguage(HttpContext) == "bg" ? "Достигнат е лимитът на каталога." : "Catalog limit reached.");
            return View(model);
        }

        model.Platforms = CombinePlatforms(model.SelectedPlatforms);

        var dto = new GameFormDto
        {
            Title = model.Title,
            Genre = model.Genre,
            Platforms = model.Platforms,
            ReleaseYear = model.ReleaseYear,
            DeveloperStudio = model.DeveloperStudio,
            PegiRating = model.PegiRating,
            Rating = model.Rating
        };

        await this.gameService.CreateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var game = await this.gameService.GetByIdAsync(id);
        if (game == null) return NotFound();

        var model = new GameFormViewModel
        {
            Title = game.Title,
            Genre = game.Genre,
            Platforms = game.Platforms,
            SelectedPlatforms = SplitPlatforms(game.Platforms),
            ReleaseYear = game.ReleaseYear,
            DeveloperStudio = game.DeveloperStudio,
            PegiRating = game.PegiRating,
            Rating = game.Rating
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, GameFormViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (!await this.gameService.ExistsAsync(id))
            return NotFound();

        model.Platforms = CombinePlatforms(model.SelectedPlatforms);

        var dto = new GameFormDto
        {
            Title = model.Title,
            Genre = model.Genre,
            Platforms = model.Platforms,
            ReleaseYear = model.ReleaseYear,
            DeveloperStudio = model.DeveloperStudio,
            PegiRating = model.PegiRating,
            Rating = model.Rating
        };

        await this.gameService.UpdateAsync(id, dto);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (!await this.gameService.ExistsAsync(id))
            return NotFound();

        await this.gameService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }


    private static GamePlatform CombinePlatforms(IEnumerable<GamePlatform> selectedPlatforms)
    {
        return selectedPlatforms.Aggregate(GamePlatform.None, (current, platform) => current | platform);
    }

    private static List<GamePlatform> SplitPlatforms(GamePlatform platforms)
    {
        return Enum.GetValues<GamePlatform>()
            .Where(platform => platform != GamePlatform.None && platforms.HasFlag(platform))
            .ToList();
    }
}
