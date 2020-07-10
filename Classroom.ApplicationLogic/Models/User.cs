using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string  PhoneNr { get; set; }
    }
}
