using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebProgrammingProject.ViewComponents.Models;

namespace WebProgrammingProject.ViewComponents
{
    public class UcakViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(UcakViewModel model)
        {

            List<int> satirEconomy = model.airplane.RowSeatNumberEconomy.Split("-").ToList().Select(x=>Convert.ToInt32(x)).ToList();
            List<int> sutunEconomy = model.airplane.ColumnSeatNumberEconomy.Split("-").ToList().Select(x => Convert.ToInt32(x)).ToList();
            List<int> satirBusiness = model.airplane.RowSeatNumberBusiness.Split("-").ToList().Select(x => Convert.ToInt32(x)).ToList();
            List<int> sutunBusiness = model.airplane.ColumnSeatNumberBusiness.Split("-").ToList().Select(x => Convert.ToInt32(x)).ToList();


            int buyuk = Math.Max(satirEconomy.Sum(), satirBusiness.Sum());
            int ucakGenislik = buyuk * 35;// kac px genisliginde olacak onu hesapliyorum.
            ucakGenislik = ucakGenislik + 20; // padding
            ucakGenislik += 100;  // koltukların satır aralarında bosluk olması icin bırakmam gerekn bosluk var bunu buraya vericem
            ViewBag.Name = model.airplane.Model;
            ViewBag.ucakGenislik = ucakGenislik;
            ViewBag.satirEconomy = satirEconomy;
            ViewBag.sutunEconomy = sutunEconomy;
            ViewBag.satirBusiness = satirBusiness;
            ViewBag.sutunBusiness = sutunBusiness;
            ViewBag.flighType = model.flightType;
            return View(model.doluKoltuklar);
        }

    }
}
