using Classroom.ApplicationLogic.Models;
using Classroom.ApplicationLogic.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Services
{
   public  class GradeServices
    {
        private readonly IGradeRepository gradeRepository;
        public GradeServices(IGradeRepository gradeRepository)
        {
            this.gradeRepository = gradeRepository;
        }
        public void Add(Homework homework, User student, float mark)
        {
            var item = gradeRepository.getByUserIdAndAssignmentId(student.UserId.ToString(),homework.Assignment.Id.ToString());
            if (item == null)
            {
                 gradeRepository.Add(new Grade() { Id = Guid.NewGuid(), StudentId = student, Homework = homework, Mark = mark });
            }
            else
            {
                item.Mark = mark;
                 gradeRepository.Update(item);
            }
        
        }
        public IEnumerable<Grade> getByAssignmentId(string id)
        {
            return gradeRepository.getByAssignmentId(id);
        }
        public Grade getByUserAndAssignment(string Userid, string AssignmentId)
        {
            return gradeRepository.getByUserIdAndAssignmentId(Userid, AssignmentId);
        }
        

    }
}
