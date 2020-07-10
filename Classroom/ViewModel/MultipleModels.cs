using Classroom.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.ViewModel
{
    public class MultipleModels
    {
        public IEnumerable<Classrooms> Classrooms { get; set; }
        public IEnumerable<Require> Requires { get; set; }
        public IEnumerable<Assignment> Assignments { get; set; }
        public Classrooms Classrom { get; set; }
        public Assignment Assignment { get; internal set; }
        public User Student { get; set; }
       
    }
}

