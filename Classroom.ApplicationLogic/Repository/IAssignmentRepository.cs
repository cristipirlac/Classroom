using Classroom.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Repository
{
   public  interface IAssignmentRepository:IRepository<Assignment>
    {
        IEnumerable<Assignment> getByClassomId(string Id);
        Assignment getById(string Id);
    }
}
