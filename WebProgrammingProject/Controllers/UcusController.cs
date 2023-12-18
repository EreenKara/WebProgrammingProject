using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProgrammingProject.Areas.Admins.Models;
using WebProgrammingProject.Models.ViewModels;

namespace WebProgrammingProject.Controllers
{
    [AllowAnonymous]
    public class UcusController : Controller
    {
        FlightManager flightManager = new FlightManager(new EfFlightDal());


        [HttpPost]
        public IActionResult Booking(FlightSearchViewModel fsModel)
        {
            if (fsModel.kacKisi < 1)
            {
                TempData["Error"] = "Lufen düzgün bir sayida yolcu sayisi giriniz.";
                return RedirectToAction("Index","Anasayfa");
            }
            List<Flight> liste = flightManager.GetFlightsWithJoin();
            List<FlightBookingViewModel> eslesenler=new List<FlightBookingViewModel>();
            foreach (Flight ucus in liste)
            {
                if(ucus.DepartureTime.Year==fsModel.neZaman.Year && 
                    ucus.DepartureTime.Month == fsModel.neZaman.Month&& ucus.DepartureTime.Day == fsModel.neZaman.Day&&
                    ucus.DepartureAirport.ID== Convert.ToInt32(fsModel.From) && ucus.ArrivalAirport.ID==Convert.ToInt32(fsModel.To))
                {
                    FlightBookingViewModel flight = new FlightBookingViewModel()
                    {
                        ID= ucus.ID,
                        Airplane=ucus.Airplane,
                        ArrivalAirport=ucus.ArrivalAirport,
                        ArrivalTime=ucus.ArrivalTime,
                        BusinessPrice=ucus.BusinessPrice,
                        EconomyPrice=ucus.EconomyPrice,
                        DepartureAirport=ucus.DepartureAirport,
                        DepartureTime=ucus.DepartureTime
                    };

                    eslesenler.Add(flight);
                }
            }

            ViewBag.kacKisi = fsModel.kacKisi;

            return View(eslesenler);
        }
    }
}
