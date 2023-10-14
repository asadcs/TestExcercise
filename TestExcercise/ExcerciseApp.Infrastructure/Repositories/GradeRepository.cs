using ExcerciseApp.Core.Entities;
using ExcerciseApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseApp.Infrastructure.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private CollegeDbContext context;

        public GradeRepository(CollegeDbContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Grade> GetAll()
        {
            return context.Grades.ToList();
        }

        public Grade GetById(int gradeId)
        {
            return context.Grades.FirstOrDefault(grade => grade.GradeId == gradeId);
        }

        public void Add(Grade grade)
        {
            if (grade == null)
            {
                throw new ArgumentNullException(nameof(grade));
            }

            context.Grades.Add(grade);
            context.SaveChanges();
        }

        public void Update(Grade grade)
        {
            if (grade == null)
            {
                throw new ArgumentNullException(nameof(grade));
            }

            var existingGrade = context.Grades.FirstOrDefault(g => g.GradeId == grade.GradeId);
            if (existingGrade != null)
            {
                existingGrade.SubjectId = grade.SubjectId;
                existingGrade.StudentId = grade.StudentId;
                existingGrade.Value = grade.Value;
                context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Grade not found");
            }
        }

        public void Delete(int gradeId)
        {
            var gradeToDelete = context.Grades.FirstOrDefault(g => g.GradeId == gradeId);
            if (gradeToDelete != null)
            {
                context.Grades.Remove(gradeToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Grade not found");
            }
        }
    }
}
