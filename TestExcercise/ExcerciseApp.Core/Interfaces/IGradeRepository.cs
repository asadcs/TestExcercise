using ExcerciseApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseApp.Core.Interfaces
{
    public interface IGradeRepository
    {
        IEnumerable<Grade> GetAll();
        Grade GetById(int gradeId);
        void Add(Grade grade);
        void Update(Grade grade);
        void Delete(int gradeId);
    }

}
