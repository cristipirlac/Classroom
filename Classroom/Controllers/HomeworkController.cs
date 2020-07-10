using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classroom.ApplicationLogic.Services;
using Classroom.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Classroom.Controllers
{
    public class HomeworkController : Controller
    {
        private readonly HomeworkServices homeworkServices;
        private readonly AssignmentService assignmentServices;
        private readonly UserServices userServices;
        private readonly UserManager<IdentityUser> userManager;

        public HomeworkController(HomeworkServices homeworkServices,AssignmentService assignmentService,UserServices userServices,UserManager<IdentityUser> userManager)
        {
            this.homeworkServices = homeworkServices;
            this.assignmentServices = assignmentService;
            this.userServices = userServices;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Index(AssignmentViewModel model)
        {
            var assignment = assignmentServices.getById(model.Id.ToString());
            var user = userServices.GetById(userManager.GetUserId(User));
            homeworkServices.Add(assignment, user, model.HomeworkLink);
            return RedirectToAction("Assignment","Assignment", new { id = model.Id });
        }
    }
}