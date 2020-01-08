using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApplication.WebApi.Dto;
using UserApplication.WebApi.Services;

namespace UserApplication.WebApi.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        //used contructor DI for injecting userService
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbums()
        {
            //var user = await _userService.GetAsync(userId);
            var albums = await _albumService.ListAsync();
            return Ok(albums);
        }
    }
}