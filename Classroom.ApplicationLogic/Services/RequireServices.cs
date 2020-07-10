using Classroom.ApplicationLogic.Models;
using Classroom.ApplicationLogic.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Services
{
    public class RequireServices
    {
        private readonly IRequireRepository requireRepository;
        public RequireServices(IRequireRepository requireRepository)
        {
            this.requireRepository = requireRepository;
        }
        public Require Add(Classrooms classroomId,User UserId)
        {
            return requireRepository.Add(new Require() { Id = Guid.NewGuid(), ClassroomId = classroomId, StudentId = UserId, Status = false });
        }
        public IEnumerable<Require> GetAll()
        {
            return requireRepository.GetAll();
        }
        public Require getById(string Id)
        {
            return requireRepository.getById(Id);
        }
        public void Update(string Id)
        {
            var request = requireRepository.getById(Id);
            request.Status = true;
            requireRepository.Update(request);
        }
        public IEnumerable<Require> getAcceptedRequests(string userId)
        {
            return requireRepository.AcceptedRequest(userId);
        }
        public Boolean Exist(string userId,string classroomId)
        {
            return requireRepository.ExistsStudentInClassrom(userId, classroomId);
        }
    }
}
