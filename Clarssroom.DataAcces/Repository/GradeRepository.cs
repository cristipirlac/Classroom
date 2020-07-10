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
    public class GradeRepository:BaseRepository<Grade>,IGradeRepository
    {
        public GradeRepository(ClassroomDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Grade> getByAssignmentId(string id)
        {
            return dbContext.Grades.Include(item => item.Homework).Include(item => item.StudentId).Where(item => item.Homework.Assignment.Id== Guid.Parse(id)).ToList();
        }
        

        public Grade getByUserIdAndAssignmentId(string UserId,string assignmentId)
        {
            return dbContext.Grades.Include(item => item.StudentId).Where(item => item.StudentId.UserId == Guid.Parse(UserId) && item.Homework.Assignment.Id == Guid.Parse(assignmentId)).FirstOrDefault();

        }
    }
}
