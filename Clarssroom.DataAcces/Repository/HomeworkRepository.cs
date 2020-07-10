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
    public class HomeworkRepository:BaseRepository<Homework>,IHomeworkRepository
    {
        public HomeworkRepository(ClassroomDbContext dbContext):base(dbContext)
        {
        }

        public IEnumerable<Homework> getByAssignmentId(string assignmentId)
        {
            return dbContext.Homeworks.Include(item => item.StudentId).Include(item => item.Assignment).Where(item => item.Assignment.Id == Guid.Parse(assignmentId)).ToList();
        }

        public Homework getById(string Id)
        {
            return dbContext.Homeworks.Include(item => item.Assignment).Include(item => item.Assignment).Where(item => item.Id == Guid.Parse(Id)).FirstOrDefault();
        }

        public Boolean getByUserAndAssignment(string User, string assignmentId)
        {
            var homework=dbContext.Homeworks.Include(item => item.StudentId).Include(item => item.Assignment).Where(item => item.StudentId.UserId == Guid.Parse(User) && item.Assignment.Id == Guid.Parse(assignmentId)).FirstOrDefault();
            if (homework != null)
                return true;
            return false;
        }
       

    }
}
