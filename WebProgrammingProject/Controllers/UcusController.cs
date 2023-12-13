using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebProgrammingProject.Controllers
{
    [AllowAnonymous]
    public class UcusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
