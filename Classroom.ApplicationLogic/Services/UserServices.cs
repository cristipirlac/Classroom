using Classroom.ApplicationLogic.Models;
using Classroom.ApplicationLogic.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.ApplicationLogic.Services
{
    public class UserServices
    {
        private readonly IUserRepository userRepository;
        public UserServices(IUserRepository user)
        {
            this.userRepository = user;
        }
       
        public User Add(string userId,string Name,string surname,string phoneNr)
        {
            return userRepository.Add(new User { UserId = Guid.Parse(userId), Name = Name, Surname = surname,PhoneNr =phoneNr});
        }
        public User GetById(string userId)
        {
            return userRepository.getById(userId);
        }
        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }
    }
}
