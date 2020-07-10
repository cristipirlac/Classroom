using Classroom.ApplicationLogic.Models;
using Classroom.ApplicationLogic.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Services
{
    public class AssignmentService
    {
        private readonly IAssignmentRepository assignmentRepository;
        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            this.assignmentRepository = assignmentRepository;
        }
        public Assignment Add(Classrooms classrooms,DateTime dueTo,string type,string link,string description)
        {
            return assignmentRepository.Add(new Assignment() { Classroom = classrooms,Type=type, PostedDate = DateTime.UtcNow, DueTo = dueTo, Link = link, Description = description, Id = Guid.NewGuid() });

        }
        public IEnumerable<Assignment> getByClassId(string Id)
        {
            return assignmentRepository.getByClassomId(Id);
        }
        public Assignment getById(string Id)
        {
            return assignmentRepository.getById(Id);
        }
        
    }
}
