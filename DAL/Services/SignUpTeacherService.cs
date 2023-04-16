using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class SignUpTeacherService : ISignUpTeacherService
    {
        private readonly StudentContext _dbContext;
        public SignUpTeacherService(StudentContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Teacher SignInTeacher(string mail, string password)
        {
            try
            {
                Teacher teacher = _dbContext.Teachers.FirstOrDefault(teacher => teacher!.Mail == mail!);
                if (teacher != null && compareHash(password, teacher.Password))
                {
                    return teacher;
                }

            }

            catch (Exception ex)
            {

                throw new ArgumentNullException(ex.Message);
            }
            return null;

        }

        public bool SignUpTeacher(Teacher teacher)
        {
            teacher.Password = EncryptPwd(teacher.Password);
            try
            {
            _dbContext.Teachers.Add(teacher);
            _dbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        private string EncryptPwd(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 10);
        }

        private bool compareHash(string originalPwd, string hashedPwd)
        {
            return BCrypt.Net.BCrypt.Verify(originalPwd, hashedPwd);
        }
    }
}
