using ExcerciseApp.Core.Entities;
using ExcerciseApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseApp.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private CollegeDbContext context;

        public CourseRepository(CollegeDbContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Course> GetAll()
        {
            return context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses.Find(id);
        }

        public void Add(Course course)
        {
            context.Courses.Add(course);
        }

        public void Update(Course course)
        {
            context.Entry(course).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var course = GetById(id);
            if (course != null)
            {
                context.Courses.Remove(course);
            }
        }
    }


}
