using Services.DTOs;

namespace Web.ViewModels.Reports;

public class ReportsIndexViewModel
{
    public IReadOnlyCollection<GameDto> HighlyRatedGames { get; set; } = new List<GameDto>();
    public IReadOnlyCollection<GameDto> RecentPcGames { get; set; } = new List<GameDto>();
    public IReadOnlyCollection<GameGenreGroupDto> KidFriendlyGroups { get; set; } = new List<GameGenreGroupDto>();
    public IReadOnlyCollection<GameGenreGroupDto> TopGamesByGenre { get; set; } = new List<GameGenreGroupDto>();
}
