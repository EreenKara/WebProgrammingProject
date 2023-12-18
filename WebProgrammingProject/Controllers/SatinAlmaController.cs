using Microsoft.AspNetCore.Mvc;
using WebProgrammingProject.Models.ViewModels;

namespace WebProgrammingProject.Controllers
{
    public class SatinAlmaController : Controller
    {
        public IActionResult SatinAlmaOnay(PassengerInformationViewModel model)
        {



            return View(model);
        }
        public IActionResult SatinAlmaTamamlandi(PassengerInformationViewModel model)
        {

            if(1==1)

            return View(model);
        }
    }
}
