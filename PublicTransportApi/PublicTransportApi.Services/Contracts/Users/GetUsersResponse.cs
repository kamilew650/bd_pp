using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Users
{
    public class GetUsersResponse : BaseContractResponse
    {
        public ICollection<UserModel> Users { get; set; }
    }
}
