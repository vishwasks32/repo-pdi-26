namespace KiranaAppV1.Infrastructure.Utils;

using KiranaAppV1.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public static class ContextSeed
{
    public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        Console.WriteLine("Seeding Roles");

        foreach(var role in Enum.GetNames(typeof(UserRole)))
        {
            if(!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // Seeding Admin User
        var adminEmail = "kiranaappv1.admin@cloudthat.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if(adminUser == null)
        {
            var newAdmin = new IdentityUser
            {
                UserName = "kiranaappv1admin",
                Email = adminEmail,
                EmailConfirmed = true
            };

            var createAdmin = await userManager.CreateAsync(newAdmin, "Admin123!");

            if(createAdmin.Succeeded)
            {
                await userManager.AddToRoleAsync(newAdmin, "Admin");
            }
        }
    }
}