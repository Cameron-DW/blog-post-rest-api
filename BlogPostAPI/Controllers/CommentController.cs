using AutoMapper;
using BlogPostAPI.Interfaces.Services;
using BlogPostAPI.Models.Dto;
using BlogPostAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        // Create Comment for Post
        [HttpPost("users/{userId}/posts/{postId}/comments")]
        public IActionResult CreateComment(long userId, long postId, [FromBody] CommentDto commentRequest)
        {
            if (!_commentService.CreateComment(userId, postId, commentRequest))
            {
                return BadRequest(ModelState);
            }

            return Ok("Comment Created");
        }

        // Get All Comments
        [HttpGet("comments")]
        public IActionResult GetAllComments()
        {
            ICollection<CommentDto> comments = _commentService.GetAllComments();

            return Ok(comments);
        }

        // Get All User Comments
        [HttpGet("users/{userId}/comments")]
        public IActionResult GetUserComments(long userId)
        {
            ICollection<CommentDto> comments = _commentService.GetUserComments(userId);

            return Ok(comments);
        }

        // Get All Post Comments
        [HttpGet("posts/{postId}/comments")]
        public IActionResult GetPostComments(long postId)
        {
            ICollection<CommentDto> comments = _commentService.GetPostComments(postId);

            return Ok(comments);
        }

        // Get Comment
        [HttpGet("comments/{commentId}")]
        public IActionResult GetPost(long commentId)
        {
            CommentDto comment = _commentService.GetComment(commentId);

            return Ok(comment);
        }


        // Update Comment
        [HttpPut("comments/{commentId}")]
        public IActionResult UpdatePost(long commentId, [FromBody] CommentDto commentRequest)
        {
            if (!_commentService.UpdateComment(commentId, commentRequest))
                return BadRequest();

            return Ok("Comment Updated");
        }

        // Delete Comment
        [HttpDelete("comments/{commentId}")]
        public IActionResult DeleteComment(long commentId)
        {
            if (!_commentService.DeleteComment(commentId))
                return BadRequest();

            return NoContent();
        }

    }
}
