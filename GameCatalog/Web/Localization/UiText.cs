using Domain.Enums;

namespace Web.Localization;

public static class UiText
{
    public const string CookieName = "GameCatalog.Language";

    private static readonly IReadOnlyDictionary<string, string> English = new Dictionary<string, string>
    {
        ["Home"] = "Home",
        ["Catalog"] = "Catalog",
        ["Reports"] = "Reports",
        ["GameClub"] = "GameClub",
        ["FooterTitle"] = "GameClub Catalog",
        ["FooterSubtitle"] = "Internal video game catalog",
        ["Language"] = "Language",
        ["English"] = "English",
        ["Bulgarian"] = "Bulgarian",
        ["DashboardTitle"] = "GameClub Dashboard",
        ["HomeEyebrow"] = "Nemetchek Bulgaria Internal Gaming Club",
        ["HomeHeading"] = "Game catalog management system",
        ["HomeIntro"] = "Browse, manage and analyze the video game collection for the internal gaming club.",
        ["BrowseCatalog"] = "Browse Catalog",
        ["AddGame"] = "Add Game",
        ["ViewReports"] = "View Reports",
        ["ImplementedRequirements"] = "Implemented requirements",
        ["ReqMaxGames"] = "Up to {0} games",
        ["ReqMultiplePlatforms"] = "Multiple platforms per game",
        ["ReqCombinedSorting"] = "Combined sorting criteria",
        ["ReqReports"] = "Required report sections",
        ["ReqFeatured"] = "Featured game priority",
        ["TotalGames"] = "Total Games",
        ["AverageRating"] = "Average Rating",
        ["KidFriendly"] = "Kid-Friendly",
        ["HighestRatedGame"] = "Highest Rated Game",
        ["Genres"] = "Genres",
        ["QuickActions"] = "Quick Actions",
        ["AcrossAllGames"] = "Across all catalog games",
        ["PegiUnder"] = "PEGI under {0}",
        ["RepresentedInCatalog"] = "Represented in the catalog",
        ["OpenCatalog"] = "Open catalog",
        ["OpenReports"] = "Open reports",
        ["AddNewGame"] = "Add New Game",
        ["NoGamesAdded"] = "No games have been added yet.",
        ["GameCatalogTitle"] = "Game Catalog",
        ["GameClubLibrary"] = "GameClub Library",
        ["CatalogDescription"] = "Search, filter, sort and manage the games in the internal club catalog.",
        ["Search"] = "Search",
        ["SearchHelp"] = "Open filters for title, developer, genre, platform, PEGI and rating",
        ["TitleOrDeveloper"] = "Title or developer...",
        ["Genre"] = "Genre",
        ["Platform"] = "Platform",
        ["AllGenres"] = "All genres",
        ["AllPlatforms"] = "All platforms",
        ["MaxPegi"] = "Max PEGI",
        ["MinRating"] = "Min Rating",
        ["ApplySearch"] = "Apply Search",
        ["Clear"] = "Clear",
        ["Games"] = "Games",
        ["SortHint"] = "Click a column header to cycle: ascending, descending, no sorting.",
        ["FeaturedPriority"] = "Featured title is prioritized",
        ["Title"] = "Title",
        ["Platforms"] = "Platforms",
        ["Year"] = "Year",
        ["Developer"] = "Developer",
        ["Rating"] = "Rating",
        ["Actions"] = "Actions",
        ["Featured"] = "Featured",
        ["Edit"] = "Edit",
        ["Delete"] = "Delete",
        ["DeleteConfirm"] = "Are you sure you want to delete this game?",
        ["NoGamesMatch"] = "No games found matching your criteria.",
        ["NoGamesFound"] = "No games found.",
        ["CatalogManagement"] = "Catalog Management",
        ["AddNewGameHeading"] = "Add new game",
        ["AddNewGameDescription"] = "Create a catalog entry with genre, supported platforms, PEGI and rating data.",
        ["EditGameHeading"] = "Edit game",
        ["EditGameDescription"] = "Update the selected game entry and keep the catalog information accurate.",
        ["BackToCatalog"] = "Back to Catalog",
        ["SaveGame"] = "Save Game",
        ["SaveChanges"] = "Save Changes",
        ["Cancel"] = "Cancel",
        ["DeveloperStudio"] = "Developer Studio",
        ["PegiRating"] = "PEGI Rating",
        ["UserRating"] = "User Rating",
        ["ChooseGenre"] = "Choose genre...",
        ["RatingRangeHelp"] = "Rating must be between {0} and {1}.",
        ["TitlePlaceholder"] = "e.g. The Legend of Code",
        ["DeveloperPlaceholder"] = "e.g. CodeForge Studio",
        ["RequiredTaskOutput"] = "Required Task Output",
        ["GameReports"] = "Game Reports",
        ["ReportsDescription"] = "Each section matches one of the required reports from the assignment.",
        ["ReportHighlyRated"] = "Games with rating above 8.5",
        ["ReportHighlyRatedSub"] = "Sorted by release year descending",
        ["ReportRecentPc"] = "PC games from the last 5 years",
        ["ReportRecentPcSub"] = "Sorted by user rating",
        ["ReportKids"] = "Games suitable for players under 12",
        ["ReportKidsSub"] = "Grouped by genre",
        ["ReportTop3"] = "Top 3 games in every genre",
        ["ReportTop3Sub"] = "If a genre has fewer than 3 games, all are shown",
        ["NoKidFriendly"] = "No kid-friendly games found.",
        ["Rpg"] = "RPG",
        ["Strategy"] = "Strategy",
        ["Action"] = "Action",
        ["Simulation"] = "Simulation",
        ["Sports"] = "Sports",
        ["Indie"] = "Indie",
        ["Adventure"] = "Adventure",
        ["Puzzle"] = "Puzzle",
        ["Shooter"] = "Shooter",
        ["Other"] = "Other",
        ["Pc"] = "PC",
        ["PlayStation"] = "PlayStation",
        ["Xbox"] = "Xbox",
        ["Switch"] = "Switch",
        ["Mobile"] = "Mobile",
        ["None"] = "None"
    };

    private static readonly IReadOnlyDictionary<string, string> Bulgarian = new Dictionary<string, string>
    {
        ["Home"] = "Начало",
        ["Catalog"] = "Каталог",
        ["Reports"] = "Справки",
        ["GameClub"] = "GameClub",
        ["FooterTitle"] = "GameClub каталог",
        ["FooterSubtitle"] = "Вътрешен каталог с видеоигри",
        ["Language"] = "Език",
        ["English"] = "English",
        ["Bulgarian"] = "Български",
        ["DashboardTitle"] = "GameClub табло",
        ["HomeEyebrow"] = "Вътрешен геймърски клуб на Немечек България",
        ["HomeHeading"] = "Система за управление на каталог с игри",
        ["HomeIntro"] = "Преглеждай, управлявай и анализирай видеоигрите за вътрешния геймърски клуб.",
        ["BrowseCatalog"] = "Отвори каталога",
        ["AddGame"] = "Добави игра",
        ["ViewReports"] = "Виж справките",
        ["ImplementedRequirements"] = "Покрити изисквания",
        ["ReqMaxGames"] = "До {0} игри",
        ["ReqMultiplePlatforms"] = "Няколко платформи за игра",
        ["ReqCombinedSorting"] = "Комбинирани критерии за сортиране",
        ["ReqReports"] = "Задължителни справки",
        ["ReqFeatured"] = "Приоритет за специалното заглавие",
        ["TotalGames"] = "Общо игри",
        ["AverageRating"] = "Средна оценка",
        ["KidFriendly"] = "Подходящи за деца",
        ["HighestRatedGame"] = "Игра с най-висока оценка",
        ["Genres"] = "Жанрове",
        ["QuickActions"] = "Бързи действия",
        ["AcrossAllGames"] = "За всички игри в каталога",
        ["PegiUnder"] = "PEGI под {0}",
        ["RepresentedInCatalog"] = "Представени в каталога",
        ["OpenCatalog"] = "Отвори каталога",
        ["OpenReports"] = "Отвори справките",
        ["AddNewGame"] = "Добави нова игра",
        ["NoGamesAdded"] = "Все още няма добавени игри.",
        ["GameCatalogTitle"] = "Каталог с игри",
        ["GameClubLibrary"] = "GameClub библиотека",
        ["CatalogDescription"] = "Търси, филтрирай, сортирай и управлявай игрите във вътрешния каталог.",
        ["Search"] = "Търсене",
        ["SearchHelp"] = "Отвори филтри за заглавие, разработчик, жанр, платформа, PEGI и оценка",
        ["TitleOrDeveloper"] = "Заглавие или разработчик...",
        ["Genre"] = "Жанр",
        ["Platform"] = "Платформа",
        ["AllGenres"] = "Всички жанрове",
        ["AllPlatforms"] = "Всички платформи",
        ["MaxPegi"] = "Макс. PEGI",
        ["MinRating"] = "Мин. оценка",
        ["ApplySearch"] = "Приложи търсенето",
        ["Clear"] = "Изчисти",
        ["Games"] = "Игри",
        ["SortHint"] = "Кликни върху заглавие на колона, за да смениш: възходящо, низходящо, без сортиране.",
        ["FeaturedPriority"] = "Специалното заглавие е с приоритет",
        ["Title"] = "Заглавие",
        ["Platforms"] = "Платформи",
        ["Year"] = "Година",
        ["Developer"] = "Разработчик",
        ["Rating"] = "Оценка",
        ["Actions"] = "Действия",
        ["Featured"] = "Специална",
        ["Edit"] = "Редакция",
        ["Delete"] = "Изтриване",
        ["DeleteConfirm"] = "Сигурен ли си, че искаш да изтриеш тази игра?",
        ["NoGamesMatch"] = "Няма игри, които отговарят на критериите.",
        ["NoGamesFound"] = "Няма намерени игри.",
        ["CatalogManagement"] = "Управление на каталога",
        ["AddNewGameHeading"] = "Добавяне на нова игра",
        ["AddNewGameDescription"] = "Създай запис с жанр, платформи, PEGI и потребителска оценка.",
        ["EditGameHeading"] = "Редакция на игра",
        ["EditGameDescription"] = "Обнови избраната игра и запази информацията в каталога актуална.",
        ["BackToCatalog"] = "Назад към каталога",
        ["SaveGame"] = "Запази игра",
        ["SaveChanges"] = "Запази промените",
        ["Cancel"] = "Отказ",
        ["DeveloperStudio"] = "Студио разработчик",
        ["PegiRating"] = "PEGI рейтинг",
        ["UserRating"] = "Потребителска оценка",
        ["ChooseGenre"] = "Избери жанр...",
        ["RatingRangeHelp"] = "Оценката трябва да бъде между {0} и {1}.",
        ["TitlePlaceholder"] = "напр. The Legend of Code",
        ["DeveloperPlaceholder"] = "напр. CodeForge Studio",
        ["RequiredTaskOutput"] = "Задължителни справки",
        ["GameReports"] = "Справки за игри",
        ["ReportsDescription"] = "Всяка секция отговаря на една от задължителните справки в условието.",
        ["ReportHighlyRated"] = "Игри с оценка над 8.5",
        ["ReportHighlyRatedSub"] = "Сортирани по година на издаване в низходящ ред",
        ["ReportRecentPc"] = "PC игри от последните 5 години",
        ["ReportRecentPcSub"] = "Сортирани по потребителска оценка",
        ["ReportKids"] = "Игри, подходящи за възраст под 12 години",
        ["ReportKidsSub"] = "Групирани по жанр",
        ["ReportTop3"] = "Топ 3 игри във всеки жанр",
        ["ReportTop3Sub"] = "Ако жанрът има под 3 игри, се показват всички",
        ["NoKidFriendly"] = "Няма намерени игри, подходящи за деца.",
        ["Rpg"] = "RPG",
        ["Strategy"] = "Стратегия",
        ["Action"] = "Екшън",
        ["Simulation"] = "Симулация",
        ["Sports"] = "Спортни",
        ["Indie"] = "Инди",
        ["Adventure"] = "Приключенски",
        ["Puzzle"] = "Пъзел",
        ["Shooter"] = "Шутър",
        ["Other"] = "Други",
        ["Pc"] = "PC",
        ["PlayStation"] = "PlayStation",
        ["Xbox"] = "Xbox",
        ["Switch"] = "Switch",
        ["Mobile"] = "Mobile",
        ["None"] = "Няма"
    };

    public static string GetLanguage(HttpContext context)
    {
        string? language = context.Request.Cookies[CookieName];
        return string.Equals(language, "bg", StringComparison.OrdinalIgnoreCase) ? "bg" : "en";
    }

    public static string T(HttpContext context, string key)
    {
        if (GetLanguage(context) == "bg" && Bulgarian.TryGetValue(key, out string? bgValue))
        {
            return bgValue;
        }

        return English.TryGetValue(key, out string? enValue) ? enValue : key;
    }

    public static string T(HttpContext context, string key, params object[] args)
    {
        return string.Format(T(context, key), args);
    }

    public static string Genre(HttpContext context, GameGenre genre)
    {
        return T(context, genre.ToString());
    }

    public static string Platform(HttpContext context, GamePlatform platform)
    {
        return T(context, platform.ToString());
    }

    public static string Platforms(HttpContext context, GamePlatform platforms)
    {
        if (platforms == GamePlatform.None)
        {
            return T(context, "None");
        }

        return string.Join(", ", Enum.GetValues<GamePlatform>()
            .Where(platform => platform != GamePlatform.None && platforms.HasFlag(platform))
            .Select(platform => Platform(context, platform)));
    }
}
