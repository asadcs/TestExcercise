using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcerciseApp.Core.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }

}