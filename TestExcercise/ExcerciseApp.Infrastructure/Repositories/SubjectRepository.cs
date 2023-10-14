using ExcerciseApp.Core.Entities;
using ExcerciseApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseApp.Core.Interfaces
{
    public class SubjectRepository : ISubjectRepository
    {
        private CollegeDbContext context; // Your Entity Framework context.

        public SubjectRepository(CollegeDbContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Subject> GetAll()
        {
            return context.Subjects.ToList();
        }

        public Subject GetById(int id)
        {
            return context.Subjects.FirstOrDefault(s => s.SubjectId == id);
        }

        public void Add(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }

            context.Subjects.Add(subject);
            context.SaveChanges();
        }

        public void Update(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }

            var existingSubject = context.Subjects.FirstOrDefault(s => s.SubjectId == subject.SubjectId);
            if (existingSubject != null)
            {
                existingSubject.Name = subject.Name;
                context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Subject not found");
            }
        }

        public void Delete(int id)
        {
            var subjectToDelete = context.Subjects.FirstOrDefault(s => s.SubjectId == id);
            if (subjectToDelete != null)
            {
                context.Subjects.Remove(subjectToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Subject not found");
            }
        }
    }
    }
