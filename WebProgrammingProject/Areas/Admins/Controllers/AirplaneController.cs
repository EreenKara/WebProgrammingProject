using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebProgrammingProject.Areas.Admins.Models;
using WebProgrammingProject.Services;

namespace WebProgrammingProject.Areas.Admins.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admins")]
    public class AirplaneController : Controller
    {
        AirplaneManager airplaneManager = new AirplaneManager(new EfAirplaneDal());
        LanguageService languageService;

        public AirplaneController(LanguageService languageService)
        {
            this.languageService = languageService;
        }
        [HttpGet]
        public async Task<IActionResult> ListAirplanes()
        {
            var liste = airplaneManager.GetList();

            return View(liste);
        }
        [HttpGet]
        public async Task<IActionResult> ShowAirplane(int id)
        {
            var airplane = airplaneManager.GetById(id);
            if(airplane!=null)
            {
                return View(airplane);
            }
            TempData["Error"] = "Boyle bir ucak bulunaamdi";
            return RedirectToAction("ListAirplanes");
        }
        [HttpGet]
        public async Task<IActionResult> CreateAirplane()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAirplane(AirplaneViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                if (airplaneManager.GetAirplaneByModel(model.AirplaneModel) == null)
                {

                    Airplane airplane = new Airplane()
                    {
                        ColumnSeatNumberBusiness = model.ColumnSeatNumberBusiness,
                        ColumnSeatNumberEconomy = model.ColumnSeatNumberBusiness,
                        RowSeatNumberBusiness = model.RowSeatNumberBusiness,
                        RowSeatNumberEconomy = model.RowSeatNumberEconomy,
                        Model = model.AirplaneModel
                    };
                    airplaneManager.Add(airplane);
                    return RedirectToAction("ListAirplanes");
                    

                }
                else
                {
                    // already exist error 
                    ModelState.AddModelError("", languageService.GetKey("HandleFlight.CreateAirplane.Error").Value);
                    return View(model);
                }
            }

            return View(model);
        }
    }
}
