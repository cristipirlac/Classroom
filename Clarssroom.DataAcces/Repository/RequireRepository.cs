using Clarssroom.DataAcces;
using Clarssroom.DataAcces.Repository;
using Classroom.ApplicationLogic.Models;
using Classroom.ApplicationLogic.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classroom.DataAcces.Repository
{
    public class RequireRepository:BaseRepository<Require>,IRequireRepository
    {
        public RequireRepository(ClassroomDbContext dbContext):base(dbContext)
        {

        }

        public IEnumerable<Require> AcceptedRequest(string userId)
        {
            return dbContext.Requires.Include(item => item.StudentId).Include(item=>item.ClassroomId).Where(item => item.StudentId.UserId == Guid.Parse(userId) && item.Status==true).ToList();
        }

        public bool ExistsStudentInClassrom(string userId, string classroomId)
        {
            var item = dbContext.Requires.Include(user=>user.StudentId).Include(user=>user.ClassroomId).Where(classroom => classroom.StudentId.UserId == Guid.Parse(userId) && classroom.ClassroomId.Id == Guid.Parse(classroomId)).FirstOrDefault();
            if (item != null)
                return true;
            return false;
        }

        public Require getById(string Id)
        {
            return dbContext.Requires.Where(item => item.Id == Guid.Parse(Id)).FirstOrDefault();
        }
    }
}
