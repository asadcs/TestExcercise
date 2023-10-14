using ExcerciseApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseApp.Core.Interfaces
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAll();
        Teacher GetById(int id);
        void Add(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(int id);
    }

}
