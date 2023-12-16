using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebProgrammingProject.Controllers
{
    [AllowAnonymous]
    public class PassengerController : Controller
    {
        public IActionResult PassengerDetails()
        {
            

            return View();
        }
    }
}
