using PublicTransportApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Interface
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
