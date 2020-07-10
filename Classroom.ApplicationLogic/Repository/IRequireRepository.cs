using Classroom.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Repository
{
    public interface IRequireRepository:IRepository<Require>
    {
        Require getById(string Id);
        IEnumerable<Require> AcceptedRequest(string userId);
        Boolean ExistsStudentInClassrom(string userId, string classroomId);
    }
}
