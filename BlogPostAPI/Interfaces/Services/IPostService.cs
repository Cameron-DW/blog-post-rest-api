using BlogPostAPI.Dto;

namespace BlogPostAPI.Interfaces.Services
{
    public interface IPostService
    {
        bool CreatePost(long userId, PostDto postRequest);
        ICollection<PostDto> GetAllPosts();
        ICollection<PostDto> GetUserPosts();
    }
}
