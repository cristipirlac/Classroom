using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Models
{
     public class Grade
    {
        public Guid Id { get; set; }
        public Homework Homework { get; set; }
        public User StudentId { get; set; }
        public float Mark { get; set; }
          
    }
}
