using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classroom.ApplicationLogic.Services;
using Classroom.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Classroom.Controllers
{
    public class GradeController : Controller
    {
        public GradeServices gradeServices;
        public UserServices userServices;
        public HomeworkServices homeworkServices;
        public GradeController(GradeServices gradeServices,UserServices userServices,HomeworkServices homeworkServices)
        {
            this.gradeServices = gradeServices;
            this.userServices = userServices;
            this.homeworkServices = homeworkServices;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(GradeViewModel model)
        {
            
            for(var i =0;i< model.StudentId.Length;i++)
            {
                var user = userServices.GetById(model.StudentId[i]);
                var homework = homeworkServices.getById(model.HomeworkId[i]);
                var mark = model.Mark[i];
                gradeServices.Add(homework, user, mark);
            }
            
            return View();
        }
    }
}