using PublicTransportApi.Services.Contracts.Courses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Models.ViewModels.Course
{
    public class CourseVM
    {
        public int Id { get; set; }
        public int CourseType { get; set; }

        public CourseModel MapToCourseModel()
        {
            var result = new CourseModel
            {
                Id = this.Id,
                CourseType = this.CourseType
            };
            return result;
        }
    }
}
