using Classroom.ApplicationLogic.Models;
using Classroom.ApplicationLogic.Services;
using Classroom.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Controllers
{
    [Authorize(Roles="Teacher")]
    public class ClassroomController : Controller
    {
        private readonly ClassroomServices classroomServices;
        private readonly UserManager<IdentityUser> userManager;
      
        private readonly RequireServices requireServices;
        public ClassroomController(ClassroomServices classroom,UserManager<IdentityUser> userManager,RequireServices requireServices)
        {
            classroomServices = classroom;
            this.userManager = userManager;
            this.requireServices = requireServices;
        }
        public IActionResult CreateClassroom()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateClassroom(ClassroomViewModel model)
        {
            classroomServices.AddClassrom(userManager.GetUserId(User), model.Name, model.ClassCode);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> AddPeople(string Id)
        {

            var user = await userManager.GetUserAsync(User);
            var usersList = new List<IdentityUser>();
            var allusers = userManager.Users;
            foreach (var item in allusers)
            {
                if(item.Id!=user.Id)
                 {
                    var role =  userManager.GetRolesAsync(item).GetAwaiter().GetResult();
                    if(role[0]=="Teacher")
                    {
                        var teacher = classroomServices.Exist(item.Id, Id);
                        if(teacher==false)
                        {
                            usersList.Add(item);
                        }
                    }else
                        if(role[0]=="Student")
                    {
                        var student = requireServices.Exist(item.Id, Id);
                        if (student == false)
                        {
                            usersList.Add(item);
                        }
                    }

                  
                 }

            }
            return View(new AddPeopleViewModel() {Users=usersList.ToList()});
        }
        [HttpPost]
        public async Task<IActionResult> AddPeople(UsersList model)
        {
            foreach(var item in model.Id)
            {
                var user = await userManager.FindByIdAsync(item);
                var role =await  userManager.GetRolesAsync(user);
                
            }
            return View();
        }





    }
    public class UsersList
    {
        public string[] Id;
    }
   
}