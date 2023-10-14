using ExcerciseApp.Core.Entities;
using ExcerciseApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ExcerciseApp.WebAPI.Controllers
{
    public class CourseController : ApiController
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController()
        {
          
        }
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public IEnumerable<Course> Get()
        {
            return _courseRepository.GetAll();
        }

        //private readonly ICourseRepository _courseRepository;

        //public CourseController(ICourseRepository courseRepository)
        //{
        //    _courseRepository = courseRepository;
        //}
        

        //[HttpGet]
        //public IEnumerable<Course> GetAllCourses()
        //{
        //    return _courseRepository.GetAll();
        //}


    }
}
