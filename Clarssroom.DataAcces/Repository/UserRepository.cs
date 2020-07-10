using System;
using System.Collections.Generic;
using System.Linq;
using Clarssroom.DataAcces;
using Clarssroom.DataAcces.Repository;
using Classroom.ApplicationLogic.Models;
using Classroom.ApplicationLogic.Repository;

namespace Classroom.DataAcces.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ClassroomDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Classrooms> GetAllByUser(string userId)
        {
            throw new System.NotImplementedException();
        }

        public User getById(string UserId)
        {
            return dbContext.Users.Where(item => item.UserId == Guid.Parse(UserId)).FirstOrDefault();
        }
    }
}
