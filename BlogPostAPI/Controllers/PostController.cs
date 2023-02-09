using AutoMapper;
using BlogPostAPI.Interfaces.Services;
using BlogPostAPI.Models.Dto;
using BlogPostAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PostController : ControllerBase
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
            ICollection<PostDto> posts = _postService.GetUserPosts(userId);

            return Ok(posts);
        }

        // Get Post
        [HttpGet("posts/{postId}")]
        public IActionResult GetPost(long postId)
        {
            PostDto post = _postService.GetPost(postId);

            return Ok(post);
        }

        // Update Post
        [HttpPut("posts/{postId}")]
        public IActionResult UpdatePost(long postId, [FromBody] PostDto postRequest)
        {
            if (!_postService.UpdatePost(postId, postRequest))
            {
                return BadRequest();

            }

            return Ok("Post Updated");
        }

        // Delete Post
        [HttpDelete("posts/{postId}")]
        public IActionResult DeletePost(long postId)
        {
            if (!_postService.DeletePost(postId))
                return BadRequest();

            return NoContent();
        }


        // Create Post for User
        [HttpPost("users/{userId}/posts")]
        public IActionResult CreatePost(long userId, [FromBody] PostDto postRequest)
        {
            if (!_postService.CreatePost(userId, postRequest))
            {
                return BadRequest(ModelState);
            }

            return Ok("Post Created");
        }
    }
}
