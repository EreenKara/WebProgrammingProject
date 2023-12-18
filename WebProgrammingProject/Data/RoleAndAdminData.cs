using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace WebProgrammingProject.Data
{
    public class RoleAndAdminData
    {
        public static async Task InitializeAsync(IServiceProvider provider)
        {
            // Normalde böyle bir şeyi koda gömmek saldırıya karşı açık hale getiriyor.
            var roleManager = provider.GetRequiredService<RoleManager<AppRole>>();
            var userManager = provider.GetRequiredService<UserManager<AppUser>>();
            var context = provider.GetRequiredService<AirLineContext>();

            if (context.Database.EnsureCreated())
            {
                string role1 = "Admin";
                string role2 = "Member";
                string password = "123123Aa.";
                if (await roleManager.FindByNameAsync(role1)==null)
                {
                    await roleManager.CreateAsync(new AppRole() {Name=role1 });
                }
                if (await roleManager.FindByNameAsync(role2) == null)
                {
                    await roleManager.CreateAsync(new AppRole() { Name = role2 });
                }
                if (await userManager.FindByNameAsync("B211210031@sakarya.edu.tr") == null)
                {
                    var person = new Adult()
                    {
                        FirstName = "Eren",
                        LastName = "Kara",
                        Email = "B211210031@sakarya.edu.tr",
                        DateofBirth = DateTime.UtcNow,
                        Gender = false,
                        Phone = "05380692857"
                    };
                    var user = new AppUser()
                    {
                        Adult = person,
                        Email= person.Email,
                        UserName=person.Email
                    };

                    var result = await userManager.CreateAsync(user,password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user,role1);
                        await userManager.AddToRoleAsync(user,role2);
                    }


                }
            }
        }
    }
}
