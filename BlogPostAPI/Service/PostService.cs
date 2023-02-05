using AutoMapper;
using BlogPostAPI.Dto;
using BlogPostAPI.Interfaces.Repository;
using BlogPostAPI.Interfaces.Services;
using BlogPostAPI.Models;
using Microsoft.Extensions.Hosting;

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

        public bool DeletePost(long postId)
        {
            Post post = _postRepository.GetPost(postId);
            return _postRepository.DeletePost(post);
        }

        public ICollection<PostDto> GetAllPosts()
        {
            ICollection<Post> posts = _postRepository.GetAllPosts();
            return _mapper.Map<ICollection<PostDto>>(posts);
        }

        public PostDto GetPost(long postId)
        {
            Post post = _postRepository.GetPost(postId);
            return _mapper.Map<PostDto>(post);
        }

        public ICollection<PostDto> GetUserPosts(long userId)
        {
            ICollection<Post> posts = _postRepository.GetUserPosts(userId);
            return _mapper.Map<ICollection<PostDto>>(posts);

        }

        public bool UpdatePost(long postId, PostDto postRequest)
        {
            Post post = _mapper.Map<Post>(postRequest);
            post.Id = postId;
            return _postRepository.UpdatePost(post);
        }
    }
}
