using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;
using System.Runtime.CompilerServices;
using WebProgrammingProject.Models.ViewModels;

namespace WebProgrammingProject.Controllers
{
    [AllowAnonymous]
    public class PassengerController : Controller
    {
        FlightManager flightManager = new FlightManager(new EfFlightDal());



        [HttpPost]
        public IActionResult PassengerDetails(PassengerDetailsViewModel model)
        {
            // Burada koltuk seçimlerinin business mı yoksa economy'mi olduğunu bunun fiyatla doğru eşleşmesini ypamadım
            // Zaman yoktu sonuçta bu bir ödev ve deadline'ı var.

            if (model.kacKisi!=model.checkedSeats.Count)
            {
                KoltukSecimiViewModel koltuk = new KoltukSecimiViewModel()
                {
                    kacKisi = model.kacKisi,
                    idAndType = model.flightId.ToString() + "-"+ model.flightType
                };
                TempData["Error"] = "Lutfen dogru sayida koltuk secin";
                return RedirectToAction("Koltuklar", "KoltukSecimi",koltuk);
            }
            

            ViewBag.flightId=model.flightId;
            ViewBag.flightType = model.flightType;
            ViewBag.kacKisi = model.kacKisi;
            ViewBag.price=model.price;
            ViewBag.checkedSeats=model.checkedSeats;
            

            return View();
        }
    }
}
