using EntityLayer.Concrete;
using FluentValidation.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebProgrammingProject.Areas.Admins.Models;
using WebProgrammingProject.Services;

namespace WebProgrammingProject.Areas.Admins.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admins")]
    public class HandleUsersController : Controller
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        private readonly LanguageService languageService;

        public HandleUsersController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, LanguageService languageService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.languageService = languageService;
        }
        public IActionResult Home()
        {


            return View();
        }

        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            
            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string roleID)
        {
            var role = await roleManager.FindByIdAsync(roleID);
            if(role==null)
            {
                TempData["Error"] = languageService.GetKey("HandleUsers.EditRole.Error").Value;
                return RedirectToAction("Home");
            }

            
            var model = new EditRoleViewModel()
            {
                ID = role.Id,
                RoleName= role.Name,

            };
            // Aşşağıdaki loop Multiple connection oluşturuyor ya fordan önce yap ve in liste deyip foeache'i calistir
            // ya da MultipleActiveResultSets=true ifadesini connection strige yapıştır.
            foreach (var user in userManager.Users) 
            {
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel editRoleModel)
        {
            var role = await roleManager.FindByIdAsync(editRoleModel.ID);
            if (role == null)
            {
                TempData["Error"] = languageService.GetKey("HandleUsers.EditRole.Error").Value;
                return RedirectToAction("Home");
            }
            else
            {
                role.Name = editRoleModel.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "HandleUsers", new { area = "Admins" });
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description );
                }
            }
            return View(editRoleModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleID)
        {
            ViewBag.RoleID = roleID;
            var role = await roleManager.FindByIdAsync(roleID);
            if(role==null)
            {
                TempData["Error"] = languageService.GetKey("HandleUsers.EditUsersInRole.Error").Value;
                return RedirectToAction("ListRoles");
            }
            var liste = new List<EditUsersInRoleViewModel>();
            foreach (var user in userManager.Users)
            {
                EditUsersInRoleViewModel model = new EditUsersInRoleViewModel()
                {
                    UserID = user.Id,
                    UserName= user.UserName,
                };
                if(await userManager.IsInRoleAsync(user,role.Name))
                {
                    model.IsSelected= true;
                }
                else
                {
                    model.IsSelected = false;
                }
                liste.Add(model);
            }

            return View(liste);

        }
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<EditUsersInRoleViewModel> liste, string roleID)
        {
            var role = await roleManager.FindByIdAsync(roleID);
            if(role == null)
            {

                TempData["Error"] = languageService.GetKey("HandleUsers.EditUsersInRole.Error").Value;
                return RedirectToAction("ListRoles");
            }

            foreach (var editUserROleModel in liste)
            {
                var user = await userManager.FindByIdAsync(editUserROleModel.UserID);
                if(user != null)
                {
                    IdentityResult result=null;
                    if (editUserROleModel.IsSelected == true && !(await userManager.IsInRoleAsync(user, role.Name)))
                    {
                        result = await userManager.AddToRoleAsync(user, role.Name);
                    }
                    else if(editUserROleModel.IsSelected == false && (await userManager.IsInRoleAsync(user, role.Name)))
                    {
                        result = await userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                    else
                    {
                        continue;
                    }
                    if(result!=null)
                    {
                        if (!result.Succeeded)
                        {
                            // kulanıcların bazılarını role ekleme veya rolden çıkarma yaparken hata oluştu
                            TempData["Error"] = languageService.GetKey("HandleUsers.EditUsersInRole.Error_AddingProblem").Value;
                            return RedirectToAction("EditRole");
                        }
                    }
                    
                }
                
            }

            // her şey başarıli ise

            

            return RedirectToAction("ListRoles");
        }
        [HttpGet]
        public IActionResult CreateRole()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            AppRole role = new AppRole()
            {
                Name = model.RoleName
            };
            IdentityResult result = await roleManager.CreateAsync(role);

            if(result.Succeeded)
            {
                return RedirectToAction("Home", "HandleUsers",new { area= "Admins"});
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View(model);
        }
    }
}
