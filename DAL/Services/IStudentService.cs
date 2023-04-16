using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Students>> GetAll();
        Task<IEnumerable<Students>> GetStudents(string roll);
        void UpdateStudent(Students model);
        void AddStudent(Students model);
        void DeleteStudent(Students model);
    }
}
