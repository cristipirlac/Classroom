using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classroom.ApplicationLogic.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Classroom
{
    public class Program
    {
        public static void InitiateAdmin(IConfiguration configuration, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, UserServices userService)
        {
            string email = "admin@yahoo.com";
            string password = "PirlacCristian1@";
            IdentityUser admin = new IdentityUser
            {
                UserName = email,
                Email = email
            };
            var adminExists = userManager.FindByEmailAsync(email).GetAwaiter().GetResult();
            if (adminExists == null)
            {
                var result = userManager.CreateAsync(admin, password).GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    //userService.AddAdmin(admin.Id, admin.Email,admin.Email);
                    var role = new IdentityRole("Administrator");
                    roleManager.CreateAsync(role).GetAwaiter().GetResult();
                    userManager.AddToRoleAsync(admin, "Administrator").GetAwaiter().GetResult();

                }
            }
            if (userManager.IsInRoleAsync(admin, "Administrator").GetAwaiter().GetResult() == false)
            {
                userManager.AddToRoleAsync(admin, "Administrator").GetAwaiter().GetResult();
            }
        }
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var userService = services.GetService<UserServices>();
                var roleManager = services.GetService<RoleManager<IdentityRole>>();
                var userManager = services.GetService<UserManager<IdentityUser>>();
                var configuration = services.GetService<IConfiguration>();
                InitiateAdmin(configuration, userManager, roleManager, userService);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
