using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamTask.DAL.Models;

namespace ExamTask.DAL.EFContext
{
    public class SeederDb
    {

        public static void SeedRoles(RoleManager<DbRole> _roleManager)
        {
            var count = _roleManager.Roles.Count();

            if (count <= 0)
            {
                var roleName = "User";
                var result = _roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;

                roleName = "Admin";
                result = _roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
            }
        }

        public static void SeedSportEquipment(EFDbContext _context)
        {
            var count = _context.Products.Count();
            if(count <= 0)
            {
                var prod = new Product
                {
                    Name = "Football Ball Nike",
                    Color = "White Blue",
                    Guarantee = "24 months",
                    Price = 145.67,
                    Available = true,
                    Image = "https://1footballbible.com.ua/wp-content/uploads/2019/04/W0635_1115_main.jpg",
                    CategoryId = _context.Categories.FirstOrDefault(x => x.CategoryName == "Football").Id
                };
                _context.Products.Add(prod);
                _context.SaveChanges();
            }
        }

        public static void SeedCategories(EFDbContext _context)
        {
            var count = _context.Categories.Count();
            if(count <= 0)
            {
                var category = new Category
                {
                    CategoryName = "Football"
                };
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
        }

        public static void SeedUsers(UserManager<DbUser> _userManager,
                                    EFDbContext _context)
        {
            var count = _userManager.Users.Count();

            if (count <= 0)
            {
                string mail = "semen@ukr.net";
                var roleName = "Admin";
                var user = new DbUser
                {
                    Email = mail,
                    UserName = mail,
                    PhoneNumber = "+380991111111",
                };

                var result = _userManager.CreateAsync(user, "Qwerty-1").Result;

                var userProfile = new UserProfile
                {
                    Id = user.Id,
                    FirstName = "Semen",
                    MiddleName = "Semenovuch",
                    LastName = "Semenuk",
                    RegistrationDate = DateTime.Now
                };

                _context.UserProfile.Add(userProfile);
                _context.SaveChanges();
                result = _userManager.AddToRoleAsync(user, roleName).Result;
            }
        }

        public static void SeedData(IServiceProvider services, IHostingEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var user_manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();

                SeederDb.SeedCategories(context);
                //SeederDb.SeedSportEquipment(context);
                SeederDb.SeedRoles(managerRole);
                //SeederDb.SeedUsers(user_manager, context);
            }
        }
    }
}