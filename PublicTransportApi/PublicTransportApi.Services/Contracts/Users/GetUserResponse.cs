using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Users
{
    public class GetUserResponse : BaseContractResponse
    {
        public UserModel User { get; set; }
    }
}
