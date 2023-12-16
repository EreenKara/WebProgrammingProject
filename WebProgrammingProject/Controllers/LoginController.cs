using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NuGet.Protocol;
using WebProgrammingProject.Models.ViewModels;
using WebProgrammingProject.Services;

namespace WebProgrammingProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly AdultManager adultManager=new AdultManager(new EfAdultDal());
        private readonly SignInManager<AppUser> signInManager;
        private readonly LanguageService languageService;
        public LoginController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, LanguageService languageService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.languageService = languageService;
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            
            

            return View();

        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp( UserRegisterViewModel registerModel)
        {
            var userExist = await userManager.FindByEmailAsync(registerModel.Adult.Email);
            if(userExist!=null)
            {
                ModelState.AddModelError("", languageService.GetKey("Login.SignUp.Error").Value);
            }
            
            if (!ModelState.IsValid)
            {
                
                return View(registerModel);
            }


            AppUser  user = new AppUser()
            {
                Adult = new Adult()
                {
                    FirstName = registerModel.Adult.FirstName,
                    LastName = registerModel.Adult.LastName,
                    Email = registerModel.Adult.Email,
                    DateofBirth = registerModel.Adult.DateofBirth,
                    Gender = registerModel.Adult.Gender,
                    Phone = registerModel.Adult.Phone

                },
                Email = registerModel.Adult.Email,
                UserName=registerModel.Adult.Email
               
            };




            string role = "Member";
            var rolevarmi = await roleManager.FindByNameAsync("Member");
            if (rolevarmi!=null)
            {
                var result = await userManager.CreateAsync(user, registerModel.Account.Password);
                await userManager.AddToRoleAsync(user, role);
                if (result.Succeeded)
                {
                    //string jsonFormat = JsonConvert.SerializeObject(registerModel);
                    //TempData["UserRegisterViewModel"] = jsonFormat;
                    //return RedirectToAction("Login");
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Anasayfa");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            ModelState.AddModelError("", languageService.GetKey("Login.SignUp.Error_RoleCannotFound").Value);


            return View(registerModel);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model,string? returnUrl)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);
                //signInManager.SignInAsync(user, isPersistent: false); // şeklinde bir verisyonu da var
                //Burada direkt olarak user'ı vererek login olabiliyoruz. isPersiseten Session mu oalcak oyoksa
                //permenant cookie mi olacak onu soruyor.
                if (result.Succeeded)
                {
                    // Local url olduğuna emin olduğumuz sitelere redirect yapıyoruz
                    if(!returnUrl.IsNullOrEmpty()&& Url.IsLocalUrl(returnUrl))
                    {
                        // aşağıdaki return LocalRedirect() hata fırlattığından koşul içerisindeki yönetimi yaptım.
                        // return LocalRedirect(returnUrl)
                        return Redirect(returnUrl);

                    }
                    else
                    {
                        //return RedirectToAction("Home","Profile",new{area="Users"});
                        return RedirectToAction("Index", "Anasayfa");
                    }
                }
                else
                {
                    ModelState.AddModelError("",languageService.GetKey("Login.Login.Error").Value);
                    return View();
                }
            }
            return RedirectToAction("Login");
        }
        [HttpPost]
        [Authorize(Roles = "Member,Admin")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Anasayfa");
        }


        /* Bu method 
         * Jquery validation işlemi yaparken bu methoda istek atıyor ( GET olarak ) 
         * Biz de ona bir response döndürüyoruz. Bu responsa göre daha bize register form POST edilmeden
         * Email valid ya da değil kontorl etmiş oluyoruz.
         * Bu validation işlemini input'tan focusu başka bir yere aldığımızda yapıyor.
         */
        // Accept verbs methodu tek bir attribute'ta kabul ettiği bütün
        // http fonksiyon yollama çeşitlerini belirtmemize yarıyor
        [AcceptVerbs("Get", "Post")]
        //[HttpPost]
        //[HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");

            }
        }



    }
}





//public async void Olustur()
//{



//    AppUser user = new AppUser()
//    {
//        Adult = new Adult()
//        {
//            FirstName = "Eren",
//            LastName = "Kara",
//            Email = "B211210031@sakarya.edu.tr",
//            DateofBirth = DateTime.UtcNow,
//            Gender = false,
//            Phone = "05380692857",

//        },
//        Email = "B211210031@sakarya.edu.tr",
//        UserName = "B211210031@sakarya.edu.tr"
//    };




//    string role = "Admin";

//    var result = await userManager.CreateAsync(user, "sau");
//    await userManager.AddToRoleAsync(user, role);
//    if (result.Succeeded)
//    {
//        //string jsonFormat = JsonConvert.SerializeObject(registerModel);
//        //TempData["UserRegisterViewModel"] = jsonFormat;
//        //return RedirectToAction("Login");
//        await signInManager.SignInAsync(user, isPersistent: false);

//    }
//    else
//    {
//        foreach (var item in result.Errors)
//        {
//            ModelState.AddModelError("", item.Description);
//        }
//    }
//    ModelState.AddModelError("", "Role bulunamadı");


//    return;


//}