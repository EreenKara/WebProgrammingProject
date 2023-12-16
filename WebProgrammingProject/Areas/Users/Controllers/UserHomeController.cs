using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebProgrammingProject.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "Member")]
    public class UserHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
