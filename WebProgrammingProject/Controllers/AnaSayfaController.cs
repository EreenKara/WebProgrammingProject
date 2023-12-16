using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WebProgrammingProject.Models;
using WebProgrammingProject.Services;

namespace WebProgrammingProject.Controllers
{
    [AllowAnonymous]
    public class AnasayfaController : Controller
    {
        AirLineContext airlineContext;

        public AnasayfaController(AirLineContext airlineContext)
        {
            this.airlineContext = airlineContext;
        }

        public IActionResult Index()
        {
            
            
            return View();
        }
       

        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(7)
                    }
            );
          
            return LocalRedirect(returnUrl);
        }

    }
}
