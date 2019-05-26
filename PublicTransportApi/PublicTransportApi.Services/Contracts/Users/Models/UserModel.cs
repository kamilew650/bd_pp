using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Failures.Models;
using PublicTransportApi.Services.Contracts.Rides.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Users.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string Token { get; set; }

        public ICollection<RideModel> Rides { get; set; }
        public ICollection<FailureModel> NotifiedFailures { get; set; }

        public UserModel(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Login = user.Login;
            Password = user.Password;
            Role = user.Role;
            Token = user.Token;

            Rides = user.Rides.Select(r => { return new RideModel(r); }).ToList();
        }
    }
}
