using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcerciseApp.Core.Entities
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public double Value { get; set; }
    }

}