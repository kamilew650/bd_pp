using Microsoft.AspNetCore.Mvc;
using PublicTransportApi.Models.ViewModels.Course;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Controllers
{
    public class CourseController : BaseController
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public IActionResult GetCourses()
        {
            return GetResult(() => _courseService.GetCourses(), r => r.Courses);
        }

        [HttpGet, Route("{courseId}")]
        public IActionResult GetCourse(int courseId)
        {
            return GetResult(() => _courseService.GetCourse(courseId), r => r.Course);
        }

        [HttpPost, Route("create")]
        public IActionResult CreateCourse([FromBody]CourseVM courseViewModel)
        {
            return GetResult(() => _courseService.CreateCourse(courseViewModel.MapToCourseModel()), r => r);
        }

        [HttpPut, Route("update")]
        public IActionResult UpdateCourse([FromBody]CourseVM courseViewModel)
        {
            return GetResult(() => _courseService.UpdateCourse(courseViewModel.MapToCourseModel()), r => r);
        }

        [HttpDelete, Route("{courseId}/delete")]
        public IActionResult DeleteCourse(int courseId)
        {
            return GetResult(() => _courseService.DeleteCourse(courseId), r => r);
        }


    }
}
