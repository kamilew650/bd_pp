using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PublicTransportApi.Common.Configurations;
using PublicTransportApi.Core;
using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Users;
using PublicTransportApi.Services.Contracts.Users.Models;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace PublicTransportApi.Services
{
    public class UserService : BaseService, IUserService
    {
        private List<User> _users = new List<User>
        {
            new User {Id = 1, FirstName = "Test", LastName = "User", Login = "test", Password = "test"}
        };

        private readonly AppSettings _appSettings;
        public UserService(DefaultDbContext dbContext, ILogger<UserService> logger, IHttpContextAccessor httpContextAccessor)
    : base(dbContext, logger, httpContextAccessor)
        {

        }

        public User Authenticate(string username, string password)
        {
            Console.WriteLine(username, password);
            var user = _users.Find(x => x.Login == username && x.Password == password);
            // return null if user not found
            if (user == null)
                return null;
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            // remove password before returning
            user.Password = null;
            return user;
        }

        public GetUsersResponse GetUsers()
        {
            return ExecuteAction<GetUsersResponse>((r) => { r.Users = _dbContext.Users.Select(u => new UserModel(u)).ToList(); });
        }

        public GetUserResponse GetUser(int userId)
        {
            return ExecuteAction<GetUserResponse>((r) =>
            {
                r.User = new UserModel(_dbContext.Users.FirstOrDefault(u => u.Id == userId));
            });
        }

        public CreateUserResponse CreateUser(UserModel userModel)
        {
            return ExecuteAction<CreateUserResponse>(r =>
            {
                var user = new User()
                {
                    Id = userModel.Id,
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Login = userModel.Login,
                    Password = userModel.Password,
                    Role = userModel.Role,
                    Token = userModel.Token,
                };
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                r.Id = user.Id;
            });
        }

        public BaseContractResponse UpdateUser(UserModel userModel)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Id == userModel.Id);
                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.Login = userModel.Login;
                user.Password = userModel.Password;
                user.Role = userModel.Role;
                user.Token = userModel.Token;
                _dbContext.Users.Update(user);
                _dbContext.SaveChanges();
            });
        }

        public BaseContractResponse DeleteUser(int userId)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);

                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            });

        }

    }
}
