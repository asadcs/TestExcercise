using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcerciseApp.Core.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }
    }

}