using Classroom.ApplicationLogic.Models;
using Classroom.ApplicationLogic.Repository;

using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Repository
{
    public interface IUserRepository:IRepository<User>
    {
        IEnumerable<Classrooms> GetAllByUser(string userId);
        User getById(string UserId);
    }
}
