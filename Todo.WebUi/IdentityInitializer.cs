using Microsoft.AspNetCore.Identity;
using Todo.Entities.Concrete;

namespace Todo.WebUi
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }
            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }


            var adminUser = await userManager.FindByNameAsync("abdulla");
            if (adminUser == null)
            {
                AppUser user = new()
                {
                    Name = "Abdulla",
                    SurName = "Oksum",
                    UserName = "Sisqo",
                    Email = "a.oksum@live.dk"
                };
                await userManager.CreateAsync(user, "1");
                await userManager.AddToRoleAsync(user, "Admin");
            }

        }

    }
}
