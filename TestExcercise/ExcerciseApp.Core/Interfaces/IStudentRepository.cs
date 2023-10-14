﻿using ExcerciseApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseApp.Core.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
    }

}
