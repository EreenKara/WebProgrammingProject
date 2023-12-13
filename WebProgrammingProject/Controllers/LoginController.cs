using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using WebProgrammingProject.Models.ViewModels;

namespace WebProgrammingProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<User> _userManager;

        public LoginController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            UserRegisterViewModel user = null;
            if (TempData["UserRegisterViewModel"] is not null)
            {
                string jsonFormat = TempData["UserRegisterViewModel"].ToString();
                user = JsonConvert.DeserializeObject<UserRegisterViewModel>(jsonFormat);
            }


            return View(user);

        }
        [HttpPost]
        public async Task<IActionResult> SignIn([Bind()]UserRegisterViewModel user)
        {
            if(user.Adult.User is null)
            {
                user.Adult.User = null;
            }
            if (!ModelState.IsValid)
            {
                TempData["Hata"] = "Bilgileriniz hatalı ya da eksik girilmiş. Lütfen tekrar deneyiniz.";
                return RedirectToAction("SignIn");
            }
            Adult adult = new Adult()
            {
                FirstName = user.Adult.FirstName,
                LastName = user.Adult.LastName,
                Email = user.Adult.Email,
                DateofBirth = user.Adult.DateofBirth,
                Gender= user.Adult.Gender,
                Phone= user.Adult.Phone,
                
            };
            User identityUser = new User()
            {
                Adult= adult
            };
            var result = await _userManager.CreateAsync(identityUser,user.Account.Password);
            if (result.Succeeded)
            {
                string jsonFormat = JsonConvert.SerializeObject(user);
                TempData["UserRegisterViewModel"] = jsonFormat;
                return RedirectToAction("SignUp");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
