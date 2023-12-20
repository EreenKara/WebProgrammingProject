using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Data;
using WebProgrammingProject.Areas.Admins.Models;
using WebProgrammingProject.Services;
using WebProgrammingProject.ViewComponents.Models;

namespace WebProgrammingProject.Areas.Admins.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admins")]
    public class FlightController : Controller
    {
        AirportManager airportManager = new AirportManager(new EfAirportDal());
        AirplaneManager airplaneManager = new AirplaneManager(new EfAirplaneDal());
        FlightManager flightManager = new FlightManager(new EfFlightDal());
        LanguageService languageService;

        public FlightController(LanguageService languageService)
        {
            this.languageService = languageService;
        }


        [HttpGet]
        public IActionResult DoluKoltuklar(int flightID)
        {
            Flight ucus= flightManager.GetFlightWithJoinById(flightID);
            List<string> takenSeats = new List<string>();
            foreach (var ticket in ucus.Tickets)
            {
                takenSeats.Add(ticket.SeatNumber);
            }
            UcakViewModel ucakModel = new UcakViewModel()
            {
                airplane = ucus.Airplane,
                doluKoltuklar = takenSeats,
                flightType = null
            };
            return View(ucakModel);
        }

        [HttpGet]
        public IActionResult ListFlights()
        {
            List<Flight> liste = flightManager.GetFlightsWithJoin();

            return View(liste);
        }


        [HttpGet]
        public IActionResult CreateFlight()
        {
            List<Airport> airportList = airportManager.GetList();


            // Bunun için viewcomponent kullanabilirsin ben uğraşmak istemedim
            List<SelectListItem> selectListItemsAirport = airportList
                .Select(airport => new SelectListItem { Value = airport.ID.ToString(), Text = airport.AirportCode }).ToList();

            ViewBag.ArrivalAirports = selectListItemsAirport;
            ViewBag.DepartureAirports = selectListItemsAirport;



            List<Airplane> airplaneList = airplaneManager.GetList();

            List<SelectListItem> selectListItemsAirplane = airplaneList
                .Select(airplaneList => new SelectListItem { Value = airplaneList.ID.ToString(), Text = airplaneList.Model }).ToList();
            ViewBag.Airplanes = selectListItemsAirplane;
            if (TempData["flight"]!=null)
            {
                var obje = JsonConvert.DeserializeObject<FlightViewModel>(TempData["flight"].ToString());
                return View(obje);
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public IActionResult CreateFlight(FlightViewModel flight)
        {
            if (ModelState.IsValid)
            {
                TempData["flight"] = JsonConvert.SerializeObject(flight);
                Airport arrivingAirport = airportManager.GetById(flight.ArrivalAirportID);
                Airport departingAirport = airportManager.GetById(flight.DepartureAirportID);
                Airplane airplane = airplaneManager.GetById(flight.AirplaneID);
                if (arrivingAirport is not null && departingAirport is not null && airplane is not null)
                {
                    if (flight.DepartureTime.CompareTo(flight.ArrivalTime)<0)
                    {
                        if (!(arrivingAirport.AirportCode==departingAirport.AirportCode))
                        {
                            Flight ucus = new Flight()
                            {
                                AirplaneID=flight.AirplaneID,
                                ArrivalTime=flight.ArrivalTime,
                                ArrivalAirportID=flight.ArrivalAirportID,
                                DepartureTime=flight.DepartureTime,
                                DepartureAirportID=flight.DepartureAirportID,
                                BusinessPrice=flight.BusinessPrice,
                                EconomyPrice=flight.EconomyPrice
                            };

                            flightManager.Add(ucus);


                            return RedirectToAction("ListFlights");
                        }
                        else
                        {
                            TempData["Error"] = "Aynı yere geri gidemezsin";
                            return RedirectToAction("CreateFlight");
                        }
                    }
                    else
                    {
                        TempData["Error"] = "Departure time arriving timedan sonra olamaz";
                        return RedirectToAction("CreateFlight");
                    }

                }
                else
                {
                    TempData["Error"] = "ucak veya airportlardan biri hatalı";
                    return RedirectToAction("CreateFlight");
                }
            }

            return RedirectToAction("CreateFlight");
        }
    }
}
