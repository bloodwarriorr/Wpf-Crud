using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public interface ISignUpTeacherService
    {
        bool SignUpTeacher(Teacher teacher);
        Teacher SignInTeacher(string mail, string password);
    }
}
