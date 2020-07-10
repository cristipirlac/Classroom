using Classroom.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Repository
{
    public interface IGradeRepository:IRepository<Grade>
    {
        IEnumerable<Grade> getByAssignmentId(string id);
        Grade getByUserIdAndAssignmentId(string UserId,string assignmentId);
    }
}
