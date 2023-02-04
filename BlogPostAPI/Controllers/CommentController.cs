using AutoMapper;
using BlogPostAPI.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            commentService = commentService;
            mapper = mapper;
        }
    }
}
