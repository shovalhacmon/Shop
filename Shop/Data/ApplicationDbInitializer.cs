//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Shop.Data
//{
//    public class ApplicationDbInitializer
//    {
//        public static void SetUsersAsAdmins(UserManager<IdentityUser> userManager, params string[] usernames)
//        {
//            IQueryable<IdentityUser> chosenUsers = from user in userManager.Users
//                                                   where usernames.Contains(user.UserName)
//                                                   select user;
//            chosenUsers.ToList().ForEach(user =>
//            {
//                userManager.AddToRoleAsync(user, "Admin").Wait();
//            });
//        }
//        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
//        {
//            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

//            IdentityResult roleResult;
//            //Adding Admin Role
//            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
//            if (!roleCheck)
//            {
//                //create the roles and seed them to the database
//                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
//            }
//            //Assign Admin role to the main User here we have given our newly registered 
//            //login id for Admin management
//            IdentityUser user = await UserManager.FindByEmailAsync("a@a.com");
//            //    ApplicationUser user2 = await UserManager.FindByEmailAsync("aa@a.com");
//            //var User = new IdentityUser();
//            var x = await UserManager.AddToRoleAsync(user, "Admin");
//            if (x.Succeeded)
//                Console.WriteLine("great");
//            // await UserManager.AddToRoleAsync(user2, "Admin");
//            var y = await UserManager.IsInRoleAsync(user, "Admin");
//            if (y)
//                Console.WriteLine("yes");

//        }
//    }
//}