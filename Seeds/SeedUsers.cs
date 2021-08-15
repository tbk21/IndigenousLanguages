using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using IndigenousLanguages.Authentication;

namespace IndigenousLanguages.API.Seeds
{
    public class Seed
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public Seed(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void SeedUsers()
        {
            if (!_userManager.Users.Any())
            { 
                var users = new List<ApplicationUser>();
                 
                var user1 = new ApplicationUser();
                user1.UserName = "BrianK"; 
                user1.Email = "BrianK@keyboarderz.com";
                users.Add(user1);
                 
                var user2 = new ApplicationUser();
                user2.UserName = "VincentiaK";
                user2.Email = "Vincentiak@keyboarderz.com";
                users.Add(user2);


                var roles = new List<ApplicationRole>
                {
                    new ApplicationRole{Name = "User"},
                    new ApplicationRole{Name = "Student"},
                    new ApplicationRole{Name = "Lecturer"},
                    new ApplicationRole{Name = "Admin"},

                };

                foreach (var role in roles)
                {
                    _roleManager.CreateAsync(role).Wait();
                }

                foreach (var user in users)
                {
                    _userManager.CreateAsync(user, "keyboarderz312!").Wait();
                    _userManager.AddToRoleAsync(user, "User").Wait();

                }

                var adminUser = new ApplicationUser
                {
                    UserName = "Admin",
                Email = "admin@keyboarderz.com"
                };
 
                IdentityResult result = _userManager.CreateAsync(adminUser, "AdminKey312").Result;
                 
                if (result.Succeeded)
                {
                    var admin = _userManager.FindByNameAsync("Admin").Result;
                    _userManager.AddToRolesAsync(admin, new[] { "Admin","User" }).Wait();
                }
 
            }
        }

    }
}
