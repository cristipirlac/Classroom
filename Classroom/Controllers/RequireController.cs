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
    public class RequireController : Controller
    {
        private readonly ClassroomServices classroomServices;
        private readonly UserServices userServices;
        private readonly RequireServices  requireServices;
        private readonly UserManager<IdentityUser> userManager;

        public RequireController(ClassroomServices classroomServices,UserServices userServices,RequireServices requireServices,UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.userServices = userServices;
            this.requireServices = requireServices;
            this.classroomServices = classroomServices;
        }
        public IActionResult Require()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Require(MultipleModels model)
        {
            var classroom = classroomServices.getByClassCode(model.Classrom.ClassCode);
            var student = userServices.GetById(userManager.GetUserId(User));
            requireServices.Add(classroom, student);
            return RedirectToAction("Index","Home");
        }
        public IActionResult Accept(string Id)
        {
            
            requireServices.Update(Id);
            return RedirectToAction("Index", "Home");
        }


    }
}