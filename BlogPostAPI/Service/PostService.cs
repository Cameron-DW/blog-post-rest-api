using AutoMapper;
using BlogPostAPI.Dto;
using BlogPostAPI.Interfaces.Repository;
using BlogPostAPI.Interfaces.Services;
using BlogPostAPI.Models;

namespace BlogPostAPI.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IUserRepository userRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public bool CreatePost(long userId, PostDto postRequest)
        {
            User user = _userRepository.GetUser(userId);
            Post post = _mapper.Map<Post>(postRequest);
            post.User = user;
            return _postRepository.CreatePost(post);
        }

        public ICollection<PostDto> GetAllPosts()
        {
            ICollection<Post> posts = _postRepository.GetAllPosts();
            return _mapper.Map<ICollection<PostDto>>(posts);
        }

        public ICollection<PostDto> GetUserPosts()
        {
            throw new NotImplementedException();
        }
    }
}
