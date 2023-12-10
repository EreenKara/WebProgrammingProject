using Microsoft.AspNetCore.Mvc;

namespace WebProgrammingProject.Controllers
{
    public class PassengerController : Controller
    {
        public IActionResult PassengerDetails()
        {
            return View();
        }
    }
}
