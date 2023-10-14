using ExcerciseApp.Core.Entities;
using ExcerciseApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseApp.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private CollegeDbContext context; // Your Entity Framework context.

        public StudentRepository(CollegeDbContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Student> GetAll()
        {
            return context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return context.Students.FirstOrDefault(s => s.StudentId == id);
        }

        public void Add(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            context.Students.Add(student);
            context.SaveChanges();
        }

        public void Update(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var existingStudent = context.Students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Student not found");
            }
        }

        public void Delete(int id)
        {
            var studentToDelete = context.Students.FirstOrDefault(s => s.StudentId == id);
            if (studentToDelete != null)
            {
                context.Students.Remove(studentToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Student not found");
            }
        }
    }

}
