using Classroom.ApplicationLogic.Models;
using Classroom.ApplicationLogic.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Services
{
    public class ClassroomServices
    {
        private readonly IClassrroomRepository classroomRepository;
        public ClassroomServices(IClassrroomRepository classroomRepository)
        {
            this.classroomRepository = classroomRepository;
        }
        public Classrooms  AddClassrom(string userId,string name,string classCode)
        {
            Guid guidUserId = Guid.Empty;
            if (Guid.TryParse(userId, out guidUserId) == true)
            {
                return classroomRepository.Add(new Classrooms() { Id = Guid.NewGuid(), UserId = guidUserId, Name = name, ClassCode = classCode });
            }
            else
            {
                throw new Exception("Entity not Found Exception");
            }
            
        }
        public Boolean Exist(string userid,string classroomId)
        {
            var item=classroomRepository.ExistsTeacherInClassrom(userid,classroomId);
            return item;
        }
        public IEnumerable<Classrooms> GetAllById(string UserId)
        {
            return classroomRepository.getUserClasses(UserId);
        }
        public Classrooms getByClassCode(string classCode)
        {
            return classroomRepository.getByClassCode(classCode);
        }
        public Classrooms getById(string Id)
        {
            return classroomRepository.getById(Id);
        }


    }
   
}
