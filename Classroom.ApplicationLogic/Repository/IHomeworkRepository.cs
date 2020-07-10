using Classroom.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Repository
{
    public interface IHomeworkRepository:IRepository<Homework>
    {
        IEnumerable<Homework> getByAssignmentId(string assignmentId);
        Boolean getByUserAndAssignment(string User, string assignmentId);
        Homework getById(string Id);
    }
}
