using Classroom.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Repository
{
    public interface IClassrroomRepository:IRepository<Classrooms>
    {
        IEnumerable<Classrooms> getUserClasses(string userId);
        Classrooms getByClassCode(string classCode);
        Classrooms getById(string Id);
        Boolean ExistsTeacherInClassrom(string userId,string classroomId);
    }
}
