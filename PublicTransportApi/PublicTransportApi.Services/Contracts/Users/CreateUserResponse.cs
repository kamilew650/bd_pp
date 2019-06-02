using PublicTransportApi.Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Contracts.Users
{
    public class CreateUserResponse : BaseContractResponse
    {
        public int Id { get; set; }
    }
}
