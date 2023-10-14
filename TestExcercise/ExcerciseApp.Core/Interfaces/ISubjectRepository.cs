using ExcerciseApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseApp.Core.Interfaces
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll();
        Subject GetById(int id);
        void Add(Subject subject);
        void Update(Subject subject);
        void Delete(int id);
    }

}
