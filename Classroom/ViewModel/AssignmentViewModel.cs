using Classroom.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.ViewModel
{
    public class AssignmentViewModel
    {
        public Guid Id { get; set; }
        public Classrooms Classroom { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime DueTo { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public IEnumerable<Assignment> Assignments { get; set; }
        public Boolean Status { get; set; }
        public Assignment Assignment { get; set; }
        public User StudentId { get; set; }
        public string HomeworkLink { get; set; }
        public IEnumerable<Grade> Grades { get; set; }
        public IEnumerable<Homework> Homeworks { get; set; }
        public float Mark { get; set; }

    }
  
}
