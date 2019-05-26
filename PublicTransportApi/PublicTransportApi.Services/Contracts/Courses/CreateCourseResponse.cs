using PublicTransportApi.Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Courses
{
    public class CreateCourseResponse : BaseContractResponse
    {
        public int Id { get; set; }
    }
}
