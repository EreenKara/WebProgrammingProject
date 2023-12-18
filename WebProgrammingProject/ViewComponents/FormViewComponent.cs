using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebProgrammingProject.ViewComponents
{
    public class FormViewComponent:ViewComponent
    {
        FlightManager flightManager = new FlightManager(new EfFlightDal());
        AirportManager airportManager= new AirportManager(new EfAirportDal());
        public IViewComponentResult Invoke()
        {
            List<Airport> liste=airportManager.GetList();
            List<SelectListItem> selectListItemsAirport = liste
                .Select(airport => new SelectListItem { Value = airport.ID.ToString(), Text = airport.AirportCode }).ToList();
            ViewBag.airports = selectListItemsAirport;
            return View();
        }

    }
}
