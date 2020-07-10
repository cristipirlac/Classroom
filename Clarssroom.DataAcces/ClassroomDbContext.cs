using Classroom.ApplicationLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Clarssroom.DataAcces
{
    public class ClassroomDbContext : DbContext
    {

       public  ClassroomDbContext(DbContextOptions<ClassroomDbContext> options)
               : base(options)
        { }
        public DbSet<Classrooms> Classrooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Require> Requires { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Grade> Grades { get; set; }
 
     }
}
