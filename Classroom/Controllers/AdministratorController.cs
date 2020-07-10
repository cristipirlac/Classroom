using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Classroom.ViewModel;
using Classroom.ApplicationLogic.Services;

namespace Classroom.Controllers
{
    [Authorize(Roles="Administrator")]
    public class AdministratorController :Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly UserServices userServices;
        public AdministratorController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager,UserServices userServices)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.userServices = userServices;
        }
        public async Task<IActionResult> Index()
        {
            var employeeList = new List<IdentityUser>();
            foreach(var employee in userManager.Users)
            {
                var role = await userManager.GetRolesAsync(employee);
                if(role.Any())
                {
                    employeeList.Add(employee);
                }
            }
            return View(new AdministratorViewModel { Employees = employeeList });
        }
        [HttpGet]
       public  IActionResult Create()
        {
            return View(new NewRoleViewModel { });

        }
        [HttpPost]
        public async Task<IActionResult> Create(NewRoleViewModel viewModel)
        {
            var identityRole = new IdentityRole(viewModel.JobName);
            await roleManager.CreateAsync(identityRole);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View(new JobsViewModel { Jobs = roleManager.Roles });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(JobsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var user = new IdentityUser { UserName = viewModel.Email, Email = viewModel.Email };
                var result = await userManager.CreateAsync(user, viewModel.Passsword);
               
                if (result.Succeeded)
                {
                    var identityRole = await roleManager.FindByIdAsync(viewModel.JobId);
                   await userManager.AddToRoleAsync(user, identityRole.Name.ToString());
                   
                }
                var createdUser = await userManager.FindByEmailAsync(viewModel.Email);
                userServices.Add(createdUser.Id, viewModel.Name, viewModel.Surname,viewModel.PhoneNr);
                return RedirectToAction("Index");
              
            }

            return RedirectToAction("CreateUser");
            
        }
    }
}