using ExcerciseApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseApp.Infrastructure.Repositories
{
    public class CourseRepository
    {
        private readonly CollegeDbContext context;

        public CourseRepository()
        {
            context = new CollegeDbContext();
        }

        public List<Course> GetAllCourses()
        {
            return context.Courses.ToList();
        }

        public void AddCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        // Implement Update and Delete methods as needed.
    }

}
