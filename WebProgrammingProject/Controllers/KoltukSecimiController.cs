using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProgrammingProject.Models.ViewModels;

namespace WebProgrammingProject.Controllers
{
    [AllowAnonymous]
    public class KoltukSecimiController : Controller
    {
        FlightManager flightManager = new FlightManager(new EfFlightDal());

        [HttpPost]
        public IActionResult Koltuklar(KoltukSecimiViewModel model)
        {
            int flightID;
            string flightType;
            try
                {
                flightID = Convert.ToInt32(model.idAndType.Split("-").ElementAt(0));
                flightType = model.idAndType.Split("-").ElementAt(1);
            }
            catch (Exception)
            {
                TempData["Error"] = "Lufen duzgun bir form gonderin";
                return RedirectToAction("Index", "Anasayfa");
            }

            Flight ucus = flightManager.GetFlightWithJoinById(flightID);
            ViewBag.flightType = flightType;
            ViewBag.price = flightType.Contains("business") ?  ucus.BusinessPrice :  ucus.EconomyPrice;
            List<string> takenSeats = new List<string>();
            foreach (var ticket in ucus.Tickets)
            {
                takenSeats.Add(ticket.SeatNumber);
            }
            ViewBag.kacKisi = model.kacKisi;
            ViewBag.takenSeats = takenSeats;
            return View(ucus);
        }
    }
}
