using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Classroom.Models;
using Microsoft.AspNetCore.Identity;
using Classroom.ApplicationLogic.Services;
using Classroom.ViewModel;

namespace Classroom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClassroomServices classroomServices;
        private readonly RequireServices requireServices;
        private readonly UserServices userServices;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public HomeController(ILogger<HomeController> logger,UserServices userServices, ClassroomServices classroomServices, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,RequireServices requireServices)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.classroomServices = classroomServices;
            _logger = logger;
            this.requireServices = requireServices;
            this.userServices = userServices;
        }

        public IActionResult Index()
        {
            if (signInManager.IsSignedIn(User))
            {

                var user = userManager.GetUserAsync(User).GetAwaiter().GetResult();
                var role = userManager.GetRolesAsync(user).GetAwaiter().GetResult();
                if (role[0] == "Teacher")
                {
                    var list = classroomServices.GetAllById(userManager.GetUserId(User));
                    var student = userServices.GetById(userManager.GetUserId(User));
                    var requireList = requireServices.GetAll();
                    var viewModel = new MultipleModels()
                    {
                        Classrooms = list,
                        Requires = requireList,
                        Student = student
                    };

                    return View(viewModel);



                }
                else 
                if (role[0]=="Student") {
                    var requireList = requireServices.getAcceptedRequests(userManager.GetUserId(User));
                    var viewModel = new MultipleModels()
                    {
                        
                        Requires = requireList,
                       
                    };

                    return View(viewModel);

                }
            }

            else
            {
                return View();
            }
            return View();
            
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
