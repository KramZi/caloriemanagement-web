using Microsoft.AspNetCore.Identity;
using System.Net;
using CaloriesManagementWeb.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace CaloriesManagementWeb.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                using (var transaction = context.Database.BeginTransaction())
                {

                    context.Database.EnsureCreated();

                    if (!context.Day_User.Any())
                    {
                        context.Day_User.AddRange(new List<Day_User>()
                        {
                        new Day_User()
                        {
                            Date = 20241026,
                            GainedCalories = 0,
                            UserId = "4b39a071-ede8-46ff-b1e1-b0b47e5e675c"
                        },
                        new Day_User()
                        {
                            Date = 20241025,
                            GainedCalories = 0,
                            UserId = "4b39a071-ede8-46ff-b1e1-b0b47e5e675c"
                        },
                        new Day_User()
                        {
                            Date = 20241026,
                            GainedCalories = 0,
                            UserId = "03706e55-c23d-4a2c-b60f-e7dca3a55727"
                        }
                    });

                    }
                    context.SaveChanges();
                    transaction.Commit();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminUserEmail = "teddysmithdeveloper@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        UserName = "teddysmithdev",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new User()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
