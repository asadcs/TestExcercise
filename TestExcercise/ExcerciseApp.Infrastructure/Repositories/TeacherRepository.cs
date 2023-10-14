using ExcerciseApp.Core.Entities;
using ExcerciseApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseApp.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private CollegeDbContext context; // Your Entity Framework context.

        public TeacherRepository(CollegeDbContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return context.Teachers.ToList();
        }

        public Teacher GetById(int id)
        {
            return context.Teachers.FirstOrDefault(t => t.TeacherId == id);
        }

        public void Add(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            context.Teachers.Add(teacher);
            context.SaveChanges();
        }

        public void Update(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            var existingTeacher = context.Teachers.FirstOrDefault(t => t.TeacherId == teacher.TeacherId);
            if (existingTeacher != null)
            {
                existingTeacher.Name = teacher.Name;
                existingTeacher.Birthday = teacher.Birthday;
                existingTeacher.Salary = teacher.Salary;
                context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Teacher not found");
            }
        }

        public void Delete(int id)
        {
            var teacherToDelete = context.Teachers.FirstOrDefault(t => t.TeacherId == id);
            if (teacherToDelete != null)
            {
                context.Teachers.Remove(teacherToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Teacher not found");
            }
        }
    }
    }
