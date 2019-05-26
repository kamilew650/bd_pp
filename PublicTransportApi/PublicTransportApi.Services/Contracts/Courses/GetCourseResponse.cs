using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Courses.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Courses
{
    public class GetCourseResponse : BaseContractResponse
    {
        public CourseModel Course { get; set; }
    }
}
