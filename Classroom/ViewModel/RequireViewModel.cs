using Classroom.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.ViewModel
{
    public class RequireViewModel
    {
        public Guid Id { get; set; }
        public Classrooms ClassroomId { get; set; }
        public User StudentId { get; set; }
        public Boolean Status { get; set; }

    }
}
