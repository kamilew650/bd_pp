using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Courses.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Courses
{
    public class GetCoursesResponse : BaseContractResponse
    {
        public ICollection<CourseModel> Courses { get; set; }
    }
}
