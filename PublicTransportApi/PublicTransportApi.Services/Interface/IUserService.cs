using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Users;
using PublicTransportApi.Services.Contracts.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Interface
{
    public interface IUserService
    {
        //User Authenticate(string username, string password);
        GetUsersResponse GetUsers();

        GetUserResponse GetUser(int userId);

        CreateUserResponse CreateUser(UserModel userModel);

        BaseContractResponse UpdateUser(UserModel userModel);

        BaseContractResponse DeleteUser(int userId);

        User Authenticate(string username, string password);

    }
}
