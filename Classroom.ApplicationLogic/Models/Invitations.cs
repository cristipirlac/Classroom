using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Models
{
    public class Invitations
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Classrooms Classroom { get; set; }
    }
}
