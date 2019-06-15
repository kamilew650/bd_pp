using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicTransportApi.Core.Entities;
using PublicTransportApi.Models.ViewModels.User;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return GetResult(() => _userService.GetUsers(), r => r.Users);
        }

        [HttpGet, Route("{userId}")]
        public IActionResult GetUser(int userId)
        {
            return GetResult(() => _userService.GetUser(userId), r => r.User);
        }

        [HttpPut, Route("create")]
        public IActionResult CreateUser([FromBody]UserVM userViewModel)
        {
            return GetResult(() => _userService.CreateUser(userViewModel.MapToUserModel()), r => r);
        }

        [HttpPut, Route("update")]
        public IActionResult UpdateUser([FromBody]UserVM userViewModel)
        {
            return GetResult(() => _userService.UpdateUser(userViewModel.MapToUserModel()), r => r);
        }

        [HttpGet, Route("{userId}/delete")]
        public IActionResult DeleteUser(int userId)
        {
            return GetResult(() => _userService.DeleteUser(userId), r => r);
        }




        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Login, userParam.Password);

            if(userParam.Login == null || userParam.Password == null)
                return BadRequest(new { message = "Brak loginu lub hasla" });
            
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

    }
}
