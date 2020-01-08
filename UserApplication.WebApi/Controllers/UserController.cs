using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApplication.WebApi.Services;

namespace UserApplication.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //used contructor DI for injecting userService
        private readonly IUserService _userService;
       
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
      
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            //int i = 0;
            //int j = 5;
            //var tp = j / i;
            var users = await _userService.ListAsync();
            return Ok(users);
        }


        //this is method is not in use as master detail concept used in angular so this method is redundent just ke[t it for reference purpose
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = await _userService.GetAsync(userId);
            return Ok(user);
        }

    }
}
