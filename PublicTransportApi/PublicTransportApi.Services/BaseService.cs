using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PublicTransportApi.Core;
using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services
{
    public class BaseService : IBaseService
    {
        protected readonly DefaultDbContext _dbContext;
        protected readonly ILogger _logger;
        private HttpContext _httpContext;

        public BaseService(DefaultDbContext dbContext, ILogger logger, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _logger = logger;
            _httpContext = httpContextAccessor.HttpContext;
        }

        protected TResponse ExecuteAction<TResponse>(Action<TResponse> action) where TResponse : BaseContractResponse, new()
        {
            var response = new TResponse();
            try
            {
                action(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

    }
}
