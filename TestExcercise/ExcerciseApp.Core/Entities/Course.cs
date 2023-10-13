using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcerciseApp.Core.Entities
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; } // Primary Key 
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }

}