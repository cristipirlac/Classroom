using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Models
{
   public  class Homework
    {
        public Guid Id { get; set; }
        public Assignment Assignment { get; set; }
        public User StudentId { get; set; }
        public string Link { get; set; }
        public Boolean Status { get; set; }
    }
}
