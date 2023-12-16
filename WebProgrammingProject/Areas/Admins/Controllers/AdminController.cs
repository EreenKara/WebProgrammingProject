using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebProgrammingProject.Areas.Admins.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admins")]
    public class AdminController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
