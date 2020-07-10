using Classroom.ApplicationLogic.Models;
using Classroom.ApplicationLogic.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Services
{
    public class HomeworkServices
    {
        private readonly IHomeworkRepository homeworkRepository;
        public HomeworkServices(IHomeworkRepository homeworkRepository)
        {
            this.homeworkRepository = homeworkRepository;
        }
        public Homework Add(Assignment assignment,User student,string link)
        {
            return homeworkRepository.Add(new Homework() { Id = Guid.NewGuid(), Assignment = assignment, StudentId = student, Link = link,Status=true });
        }
        public IEnumerable<Homework> getByAssignmentId(string assignmentId)
        {
            return homeworkRepository.getByAssignmentId(assignmentId);
        }
        public Boolean getbyUserAndAssignment(string User,string assignmentId)
        {
            return homeworkRepository.getByUserAndAssignment(User, assignmentId);
        }
        public Homework getById(string Id)
        {
            return homeworkRepository.getById(Id);
        }
    }
}
