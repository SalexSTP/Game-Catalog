using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.ViewModels.Games;

public class GameIndexViewModel
{
    public string? SearchTerm { get; set; }
    public GameGenre? Genre { get; set; }
    public GamePlatform? Platform { get; set; }
    public int? MaxPegiRating { get; set; }
    public decimal? MinRating { get; set; }

    public string? SortField1 { get; set; }
    public bool SortDescending1 { get; set; }
    public string? SortField2 { get; set; }
    public bool SortDescending2 { get; set; }
    public string? SortField3 { get; set; }
    public bool SortDescending3 { get; set; }

    public IReadOnlyCollection<Services.DTOs.GameDto> Games { get; set; } = new List<Services.DTOs.GameDto>();

    public SelectList Genres { get; set; } = null!;
    public SelectList Platforms { get; set; } = null!;
}
