using Microsoft.AspNetCore.Mvc;
using Web.Localization;

namespace Web.Controllers;

public class LanguageController : Controller
{
    [HttpPost]
    public IActionResult Set(string language, string? returnUrl = null)
    {
        string selectedLanguage = string.Equals(language, "bg", StringComparison.OrdinalIgnoreCase) ? "bg" : "en";

        Response.Cookies.Append(
            UiText.CookieName,
            selectedLanguage,
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1),
                IsEssential = true,
                SameSite = SameSiteMode.Lax
            });

        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
        {
            return LocalRedirect(returnUrl);
        }

        return RedirectToAction("Index", "Home");
    }
}
