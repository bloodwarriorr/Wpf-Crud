using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentContext _dbContext;
        public StudentService(StudentContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddStudent(Students model)
        {

            _dbContext.students.Add(model);
            _dbContext.SaveChanges();

        }
        public void DeleteStudent(Students model)
        {

            _dbContext.students.Remove(model);
            _dbContext.SaveChanges();


        }
        public void UpdateStudent(Students model)
        {
            _dbContext.students.Update(model);
            _dbContext.SaveChanges();
        }
        public async Task<IEnumerable<Students>> GetAll()
        {

            return await _dbContext.students.ToListAsync();

        }
        public async Task<IEnumerable<Students>> GetStudents(string roll)
        {
            IEnumerable<Students> students = await GetAll();
            return from student in students where student.Roll == roll select student;
        }
    }
}
