using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Classroom.ApplicationLogic.Models
{
   public  class Assignment
    {
        [Key]
        public Guid Id { get; set; }
        public Classrooms Classroom { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime DueTo { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
