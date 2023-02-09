using AutoMapper;
using BlogPostAPI.Interfaces.Services;
using BlogPostAPI.Models;
using BlogPostAPI.Models.Dto;
using BlogPostAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // Get User
        [HttpGet]
        public IActionResult GetUsers()
        {
            ICollection<UserDto> users = _userService.GetAllUsers();

            return Ok(users);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUser(long userId) {
            UserDto user = _userService.GetUser(userId);
            return Ok(user);
        }

        // Create User
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto userRequest)
        {
            if (!_userService.CreateUser(userRequest)) {
                return BadRequest();
            }

            return Ok("User Created");
        }

        // Update User
        [HttpPut("{userId}")]
        public IActionResult UpdateUser(long userId, [FromBody] UserDto userRequest)
        {
            if (!_userService.UpdateUser(userId, userRequest))
            {
                return BadRequest();
            }

            return Ok("User Updated");
        }


        // Delete User
        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(long userId)
        {
            if (!_userService.DeleteUser(userId))
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
