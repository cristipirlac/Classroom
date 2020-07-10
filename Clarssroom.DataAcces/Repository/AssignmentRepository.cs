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
    public class AssignmentRepository:BaseRepository<Assignment>,IAssignmentRepository
    {
        public AssignmentRepository(ClassroomDbContext dbContext):base(dbContext)
        {
        }

        public IEnumerable<Assignment> getByClassomId(string Id)
        {
            return dbContext.Assignments.Include(classroom => classroom.Classroom).Where(item => item.Classroom.Id == Guid.Parse(Id)).OrderBy(item=>item.PostedDate).ToList();
        }

        public Assignment getById(string Id)
        {
            return dbContext.Assignments.Where(item => item.Id == Guid.Parse(Id)).SingleOrDefault();
        }

        
    }
}
