using Classroom.ApplicationLogic.Models;
using Classroom.ApplicationLogic.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clarssroom.DataAcces.Repository
{
    public class ClassroomRepository:BaseRepository<Classrooms>,IClassrroomRepository
    {
        public ClassroomRepository(ClassroomDbContext dbContext):base(dbContext)
        { }

        public bool ExistsTeacherInClassrom(string userId,string classroomId)
        {
            var item = dbContext.Classrooms.Where(classroom => classroom.UserId == Guid.Parse(userId) && classroom.Id==Guid.Parse(classroomId)).FirstOrDefault();
            if (item != null)
                return true;
            return false;
        }

        public bool ExistsTeacherInClassroom(string ClassroomCode)
        {
            var item = dbContext.Classrooms.Where(classroom => classroom.ClassCode == ClassroomCode).FirstOrDefault();
            if (item!=null)
                return true;
            return false;

        }

        public Classrooms getByClassCode(string classCode)
        {
            return dbContext.Classrooms.Where(item => item.ClassCode == classCode).FirstOrDefault();
        }
        public Classrooms getById(string Id)
        {
            return dbContext.Classrooms.Where(item => item.Id == Guid.Parse(Id)).FirstOrDefault();
        }

        public IEnumerable<Classrooms> getUserClasses(string userId)
        {
            return dbContext.Classrooms.Where(item => item.UserId == Guid.Parse(userId)).ToList();
        }
    }
}
