using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Teacher
    {
        [Key]
        public Guid Id { get; set; }
        public string Mail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Roll { get; set; }

        public Teacher()
        {

        }

        public Teacher(Guid guid,string mail, string firstName, string lastName, string password, string roll)
        {
            Id = guid;
            Mail = mail;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Roll = roll;
        }
    }
}
