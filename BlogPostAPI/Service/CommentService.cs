using AutoMapper;
using BlogPostAPI.Interfaces.Repository;
using BlogPostAPI.Interfaces.Services;

namespace BlogPostAPI.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
    }
}
