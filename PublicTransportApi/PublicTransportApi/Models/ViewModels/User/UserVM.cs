using PublicTransportApi.Services.Contracts.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Models.ViewModels.User
{
    public class UserVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string Token { get; set; }
        public UserModel MapToUserModel()
        {
            var result = new UserModel
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Login = this.Login,
                Password = this.Password,
                Role = this.Role,
                Token = this.Token
            };
            return result;
        }
    }
}
