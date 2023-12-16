using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebProgrammingProject.Areas.Users.Models;

namespace WebProgrammingProject.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "Member")]
    public class ProfileController : Controller
    {
        UserManager<AppUser> userManager;
        AdultManager adultManager = new AdultManager(new EfAdultDal());
        public ProfileController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Home()
        {
            var values = await userManager.FindByNameAsync(User.Identity.Name);
            var adult = adultManager.GetById(values.AdultID);
            UserProfileViewModel model = new UserProfileViewModel();
            model.Name = adult.FirstName;
            model.SurName= adult.LastName;
            model.Email = adult.Email;
            model.Phone = adult.Phone;
            model.DateofBirth = adult.DateofBirth;
                
            return View(model);
        }
        public async Task<IActionResult> Settings()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Settings(UserEditProfileViewModel model)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                return RedirectToAction("Login","Login");
            }

            return View();
        }
    }
}
