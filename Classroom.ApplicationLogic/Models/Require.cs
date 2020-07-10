using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Models
{
    public class Require
    {
        public Guid Id { get; set; }
        public Classrooms ClassroomId { get; set; }
        public User StudentId { get; set; }
        public Boolean Status { get; set; }


    }
}

