using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Text.Json.Nodes;
using WebProgrammingProject.Areas.Admins.Models;
using WebProgrammingProject.Services;

namespace WebProgrammingProject.Areas.Admins.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admins")]
    //[Route("[controller]/")]
    public class AirportController : Controller
    {
        AirportManager airportManager = new AirportManager(new EfAirportDal());
        LanguageService languageService;
        HttpClient client;
         

        public AirportController(LanguageService languageService)
        {
            this.languageService = languageService;
            client = new HttpClient();
        }
        
        public async Task<IActionResult> ListAirports()
        {
            List<Airport> liste;
            var response = await client.GetAsync("https://localhost:7070/api/airports/join");
            var responsetext = await response.Content.ReadAsStringAsync();
            liste = JsonConvert.DeserializeObject<List<Airport>>(responsetext);

            return View(liste);

        }
        [HttpGet]
        public async Task<IActionResult> CreateAirport()
        {
            

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateAirport(AirportViewModel model)
        {
            if (ModelState.IsValid)
            {

                var response = await client.GetAsync($"https://localhost:7070/api/airports/code/{model.AirportCode}");

                //var responseText = await response.Content.ReadAsStringAsync();
                //Airport airport = JsonConvert.DeserializeObject<Airport>(responseText);
                if (response.StatusCode==HttpStatusCode.NotFound)
                {

                    Airport airport = new Airport()
                    {
                        AirportCode= model.AirportCode,
                        Country=model.Country,
                        City=model.City,
                    };
                    //JsonContent jsonContent = JsonContent.Create(airport);
                    var eklendimi = await client.PostAsJsonAsync($"https://localhost:7070/api/airports", airport);

                    return RedirectToAction("ListAirports");
                    
                    
                }
                else
                {
                    ModelState.AddModelError("", languageService.GetKey("Aiport.CreateAirport.AlreadyExist").Value);
                }

            }

            return View(model);
        }
    }
}
