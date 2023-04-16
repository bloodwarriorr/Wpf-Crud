using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options):base(options) 
        {
            Database.EnsureCreated();

        }

        public DbSet<Students> students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>().HasData(
                new Students
                {
                    StudentId = Guid.NewGuid(),
                    Name = "Student1",
                    Roll = "1001"
                },
                 new Students
                 {
                     StudentId = Guid.NewGuid(),
                     Name = "Student2",
                     Roll = "1002"
                 },
                  new Students
                  {
                      StudentId = Guid.NewGuid(),
                      Name = "Student3",
                      Roll = "1003"
                  }
                );
            modelBuilder.Entity<Teacher>().HasData(
               new Teacher
               {
                   Id = Guid.NewGuid(),
                   FirstName = "Moshe",
                   LastName ="David",
                   Mail = "Moshe@gmail.com",
                   Password= BCrypt.Net.BCrypt.HashPassword("moshe123",10),
                   Roll="1001"
               },
                new Teacher
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Yosi",
                    LastName = "Tsabari",
                    Mail = "Yosi@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("yosi123", 10),
                    Roll = "1002"
                },
                 new Teacher
                 {
                     Id = Guid.NewGuid(),
                     FirstName = "Efi",
                     LastName = "Menashe",
                     Mail = "Efi@gmail.com",
                     Password = BCrypt.Net.BCrypt.HashPassword("efi123", 10),
                     Roll = "1003"
                 }
               );
        }
    }
}
