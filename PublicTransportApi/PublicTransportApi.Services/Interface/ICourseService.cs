using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Courses;
using PublicTransportApi.Services.Contracts.Courses.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Interface
{
    public interface ICourseService
    {
        GetCoursesResponse GetCourses();
        GetCourseResponse GetCourse(int CourseId);
        CreateCourseResponse CreateCourse(CourseModel courseModel);
        BaseContractResponse UpdateCourse(CourseModel courseModel);
        BaseContractResponse DeleteCourse(int courseId);

    }
}
