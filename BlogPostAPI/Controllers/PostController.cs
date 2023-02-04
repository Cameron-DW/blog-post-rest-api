using AutoMapper;
using BlogPostAPI.Dto;
using BlogPostAPI.Interfaces.Services;
using BlogPostAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper) {
            _postService = postService;
            _mapper = mapper;
        }

        // Get All Posts
        [HttpGet("posts")]
        public IActionResult GetAllPosts()
        {
            ICollection<PostDto> posts = _postService.GetAllPosts();

            return Ok(posts);
        }

        // Get All User Posts
        [HttpGet("users/{userId}/posts")]
        public IActionResult GetUserPosts(long userId)
        {
            ICollection<PostDto> posts = _postService.GetUserPosts();

            return Ok(posts);
        }


        // Create Post for User
        [HttpPost("users/{userId}/posts")]
        public IActionResult CreatePost(long userId, [FromBody] PostDto postRequest)
        {
            if (!_postService.CreatePost(userId, postRequest))
            {
                return BadRequest("Could not create Post");
            }

            return Ok("Post Created");
        }
    }
}
