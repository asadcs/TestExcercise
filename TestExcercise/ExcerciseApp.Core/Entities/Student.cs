using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcerciseApp.Core.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string RegistrationNumber { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }

}