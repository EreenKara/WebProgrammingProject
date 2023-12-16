using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace WebProgrammingProject.Areas.Admins.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admins")]
    public class HandleFlightController : Controller
    {
        AirportManager airportManager = new AirportManager(new EfAirportDal());
        AirplaneManager airplaneManager = new AirplaneManager(new EfAirplaneDal());

        public async Task<IActionResult> Home()
        {
            return View();
        }


        public IActionResult Index()
        {
            List<Airport> airportList = airportManager.GetList();

            List<SelectListItem> selectListItemsAirport = airportList
                .Select(airport => new SelectListItem { Value = airport.ID.ToString(), Text = airport.AirportCode }).ToList();

            ViewBag.ArrivalAirports = selectListItemsAirport;
            ViewBag.DepartureAirports = selectListItemsAirport;



            List<Airplane> airplaneList = airplaneManager.GetList();

            List<SelectListItem> selectListItemsAirplane = airplaneList
                .Select(airplaneList => new SelectListItem { Value = airplaneList.ID.ToString(), Text = airplaneList.Model }).ToList();
            ViewBag.Airplanes = selectListItemsAirplane;

            return View();
        }
    }
}
