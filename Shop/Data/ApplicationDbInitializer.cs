using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public static class ApplicationDbInitializer
    {
        //sets the users (gets array of users' emails) as admins
        public static async Task SeedAdminUsers(IServiceProvider serviceProvider
            , params string[] usersEmails)
        {

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string adminString = "Admin";
            //Adding Admin Role
            bool isAdminRoleExists = await roleManager.RoleExistsAsync(adminString);
            if (!isAdminRoleExists)
            {
                //create the roles and seed them to the database
                await roleManager.CreateAsync(new IdentityRole(adminString));
            }

            foreach (string userEmail in usersEmails)
            {
                //login id for Admin management
                IdentityUser user = await userManager.FindByEmailAsync(userEmail);
                if (user != null)
                {
                    IdentityResult result = await userManager.AddToRoleAsync(user, adminString);
                    result = await userManager.UpdateAsync(user);
                }
            };

        }
    }
}