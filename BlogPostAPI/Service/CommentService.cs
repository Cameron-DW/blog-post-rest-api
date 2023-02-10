using AutoMapper;
using BlogPostAPI.Interfaces.Repository;
using BlogPostAPI.Interfaces.Services;
using BlogPostAPI.Models;
using BlogPostAPI.Models.Dto;

namespace BlogPostAPI.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CommentService(
            ICommentRepository commentRepository,
            IUserRepository userRepository,
            IPostRepository postRepository,
            IMapper mapper)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public bool CreateComment(long userId, long postId, CommentDto commentRequest)
        {
            User user = _userRepository.GetUser(userId);
            Post post = _postRepository.GetPost(postId);
            Comment comment = _mapper.Map<Comment>(commentRequest);
            comment.User = user;
            comment.Post = post;
            return _commentRepository.CreateComment(comment);
        }

        public ICollection<CommentDto> GetAllComments()
        {
            ICollection<Comment> comments = _commentRepository.GetAllComments();
            return _mapper.Map<ICollection<CommentDto>>(comments);
        }

        public ICollection<CommentDto> GetUserComments(long userId)
        {
            ICollection<Comment> comments = _commentRepository.GetUserComments(userId);
            return _mapper.Map<ICollection<CommentDto>>(comments);
        }

        public ICollection<CommentDto> GetPostComments(long postId)
        {
            ICollection<Comment> comments = _commentRepository.GetPostComments(postId);
            return _mapper.Map<ICollection<CommentDto>>(comments);
        }

        public CommentDto GetComment(long commentId)
        {
            Comment comment = _commentRepository.GetComment(commentId);
            return _mapper.Map<CommentDto>(comment);
        }

        public bool UpdateComment(long commentId, CommentDto commentRequest)
        {
            Comment comment = _mapper.Map<Comment>(commentRequest);
            comment.Id = commentId;
            return _commentRepository.UpdateComment(comment);
        }

        public bool DeleteComment(long commentId)
        {
            Comment comment = _commentRepository.GetComment(commentId);
            return _commentRepository.DeleteComment(comment);
        }
    }
}
