using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Models
{
    public class Classrooms
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string ClassCode { get; set; }
    }
}
