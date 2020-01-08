using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApplication.Services;

namespace UserApplication.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
       
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
      
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.ListAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = await _userService.GetAsync(userId);
            return Ok(user);
        }

    }
}
