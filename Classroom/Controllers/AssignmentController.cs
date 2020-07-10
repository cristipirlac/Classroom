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
    public class AssignmentController : Controller
    {
        private readonly AssignmentService assignmentService;
        private readonly ClassroomServices classroomServices; 
        private readonly HomeworkServices homeworkServices; 
        private readonly GradeServices gradeServices; 
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AssignmentController(AssignmentService assignmentService,GradeServices gradeServices,ClassroomServices classroomServices,HomeworkServices homeworkServices,UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            this.assignmentService = assignmentService;
            this.classroomServices = classroomServices;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.homeworkServices = homeworkServices;
            this.gradeServices = gradeServices;
        }
        public IActionResult Index(string Id)
        {
            var assignment = assignmentService.getByClassId(Id);
            var clasroom = classroomServices.getById(Id);
            var viewModel = new AssignmentViewModel()
            {   
                Classroom = clasroom,
                Assignments = assignment,
                DueTo = DateTime.UtcNow,
               
            };
            return View(viewModel);
        }
        [HttpPost]
       public IActionResult Index(AssignmentViewModel model)
        {
            var classroom = classroomServices.getById(model.Classroom.Id.ToString());
            if(model.Type=="course")
            {
                string type = model.Type;
                assignmentService.Add(classroom, default(DateTime),type, model.Link, model.Description);
            }
            else
                if(model.Type=="assignment")
            {
                string type = model.Type;
                assignmentService.Add(classroom, model.DueTo, type, model.Link, model.Description);

            }
            else
            {
                string type = "announcment";
                assignmentService.Add(classroom,default(DateTime), type, null, model.Description);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Assignment(string Id)
        {

            var user = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            var role = userManager.GetRolesAsync(user).GetAwaiter().GetResult();
            if (role[0] == "Teacher") {
                var homework = homeworkServices.getByAssignmentId(Id);
                var grade = gradeServices.getByAssignmentId(Id);
                var assignment = assignmentService.getById(Id);
                var viewModel = new AssignmentViewModel()
                {
                    Grades = grade,
                    Homeworks=homework,
                    Link = assignment.Link
                };
                return View(viewModel);
            }
            else
                if (role[0] == "Student")
            {
                
                var assignment = assignmentService.getById(Id);
                if (assignment.Type == "assignment")
                {
                    float grade = 0;
                    var homework = homeworkServices.getbyUserAndAssignment(userManager.GetUserId(User), assignment.Id.ToString());
                    if(homework==true)
                    {
                        var mark = gradeServices.getByUserAndAssignment(userManager.GetUserId(User), Id);
                        if (mark != null)
                        {
                            grade = mark.Mark;
                        }
                    }
                    var viewModel = new AssignmentViewModel()
                    {
                        Id = Guid.Parse(Id),
                        DueTo = assignment.DueTo,
                        Link = assignment.Link,
                        Description = assignment.Description,
                        Type = assignment.Type,
                        Status = homework,
                        Mark = grade



                    };
                  

                    return View(viewModel);
                }
                else
                    if(assignment.Type=="course")
                {
                    var viewModel = new AssignmentViewModel()
                    {
                        Id = Guid.Parse(Id),
                        DueTo = assignment.DueTo,
                        Link = assignment.Link,
                        Description = assignment.Description,
                        Type = assignment.Type,
                    };

                    return View(viewModel);
                }

            }
            return View();
        }


    }
   

}