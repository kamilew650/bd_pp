using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PublicTransportApi.Services.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PublicTransportApi.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    //[EnableCors("MyPolicy")]
    public class BaseController : Controller
    {
        protected IActionResult GetResult<T>(Func<T> action, Func<T, object> result) where T : BaseContractResponse
        {
            var response = action();
            if (!response.Success)
                return CustomValidationError(response.ErrorMessage);
            return Json(result(response));

        }

        protected ObjectResult CustomValidationError(string message)
        {
            var obj = new { message = message };
            return StatusCode((int)HttpStatusCode.Conflict, obj);
        }


    }
}
