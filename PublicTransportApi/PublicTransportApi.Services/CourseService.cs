using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PublicTransportApi.Core;
using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Courses;
using PublicTransportApi.Services.Contracts.Courses.Models;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Services
{
    class CourseService : BaseService, ICourseService
    {
        public CourseService(DefaultDbContext dbContext, ILogger<CourseService> logger, IHttpContextAccessor httpContextAccessor) : base(dbContext, logger, httpContextAccessor)
        {
        }

        public GetCoursesResponse GetCourses()
        {
            return ExecuteAction<GetCoursesResponse>(r => { r.Courses = _dbContext.Courses.Select(f => new CourseModel(f)).ToList(); });
        }

        public GetCourseResponse GetCourse(int CourseId)
        {
            return ExecuteAction<GetCourseResponse>((r) =>
            {
                r.Course = new CourseModel(_dbContext.Courses.FirstOrDefault(u => u.Id == CourseId));
            });
        }

        public CreateCourseResponse CreateCourse(CourseModel courseModel)
        {
            return ExecuteAction<CreateCourseResponse>(r =>
            {
                var course = new Course()
                {
                    Id = courseModel.Id,
                    CourseType = courseModel.CourseType,
                };
                _dbContext.Courses.Add(course);
                _dbContext.SaveChanges();
                r.Id = course.Id;
            });
        }


        public BaseContractResponse UpdateCourse(CourseModel courseModel)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var course = _dbContext.Courses.FirstOrDefault(u => u.Id == courseModel.Id);
                course.Id = courseModel.Id;
                course.Id = courseModel.CourseType;
                _dbContext.Courses.Update(course);
                _dbContext.SaveChanges();
            });
        }

        public BaseContractResponse DeleteCourse(int courseId)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var course = _dbContext.Courses.FirstOrDefault(v => v.Id == courseId);

                _dbContext.Courses.Remove(course);
                _dbContext.SaveChanges();
            });
        }
    }
}
