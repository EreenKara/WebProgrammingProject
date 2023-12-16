using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebProgrammingProject.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "Member")]
    public class MyFlightsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
