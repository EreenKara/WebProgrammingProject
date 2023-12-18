using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebProgrammingProject.Models.ViewModels;

namespace WebProgrammingProject.Controllers
{
    [AllowAnonymous]
    public class SatinAlmaController : Controller
    {
        ShoppingCartManager spCartManageer = new ShoppingCartManager(new EfShoppingCartDal());
        AdultManager adultManager = new AdultManager(new EfAdultDal());
        TicketManager ticketManager = new TicketManager(new EfTicketDal());


        [HttpPost]
        public IActionResult SatinAlmaOnay(PassengerInformationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Gereken bilgileri eksik veya hatali girdiniz.";
                return RedirectToAction("Index", "Anasayfa");
            }
            if (model.Gender.Count!=model.kacKisi||
                model.FirstName.Count != model.kacKisi || model.LastName.Count != model.kacKisi || 
                model.DateofBirth.Count != model.kacKisi || model.Email.Count != model.kacKisi ||
                model.Tel.Count != model.kacKisi || model.Accept.Count != model.kacKisi)
            {
                TempData["Error"] = "Herkes için bilgi girmediniz.";
                return RedirectToAction("Index", "Anasayfa");
            }
            
            return View(model);
        }
        [HttpPost]
        public IActionResult SatinAlmaTamamlandi(PassengerInformationViewModel model,string kimOdedi)
        {

            // Normal şartlarda shopping cart burda olmamalı ancak zaman yoktu kolayıma gideni yaptım

            if(kimOdedi.IsNullOrEmpty())
            {
                TempData["Error"] = "Kim odedi secmediniz.";
                return RedirectToAction("Index", "Anasayfa");
            }
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Gereken bilgileri eksik veya hatali girdiniz.";
                return RedirectToAction("Index", "Anasayfa");
            }
            if (model.Gender.Count != model.kacKisi ||
                model.FirstName.Count != model.kacKisi || model.LastName.Count != model.kacKisi ||
                model.DateofBirth.Count != model.kacKisi || model.Email.Count != model.kacKisi ||
                model.Tel.Count != model.kacKisi || model.Accept.Count != model.kacKisi)
            {
                TempData["Error"] = "Herkes için bilgi girmediniz.";
                return RedirectToAction("Index", "Anasayfa");
            }

            HashSet<Ticket> tickets = new HashSet<Ticket>();
            HashSet<Adult> people = new HashSet<Adult>();
            for (int i = 0; i < model.kacKisi; i++)
            {
                
                Adult p = new Adult()
                {
                    FirstName = model.FirstName[i],
                    LastName = model.LastName[i],
                    Email = model.Email[i],
                    DateofBirth = model.DateofBirth[i],
                    Gender = model.Gender[i],
                    Phone = model.Tel[i]
                };
                Ticket t = new Ticket()
                {
                    FlightType = model.type,
                    SeatNumber = model.checkedSeats[i],
                    Price = model.price,
                    FlightID = Convert.ToInt32(model.id),
                    Person = p
                };
                tickets.Add(t);
                people.Add(p);

            }
            ShoppingCart spCart = new ShoppingCart()
            {
                Tickets = tickets,
                TotalPrice = tickets.Sum(x => x.Price),
                WhoPaid = people.ElementAt(Convert.ToInt32(kimOdedi))
            };
            //ticket shooing eslestir
            //people.ToList().ForEach(p => adultManager.Add(p));
            //tickets.ToList().ForEach(t => ticketManager.Add(t));

            spCartManageer.Add(spCart);
            return View();
        }
    }
}
