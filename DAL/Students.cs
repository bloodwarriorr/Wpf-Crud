using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Students
    {
        [Key]
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string Roll { get; set; }
        public Students()
        {

        }
        public Students(Guid studentId, string name, string roll)
        {
            StudentId = studentId;
            Name = name;
            Roll = roll;
        }
    }
}
