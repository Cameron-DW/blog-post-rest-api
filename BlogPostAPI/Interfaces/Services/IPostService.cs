
using BlogPostAPI.Models.Dto;

namespace BlogPostAPI.Interfaces.Services
{
    public interface IPostService
    {
        bool CreatePost(long userId, PostDto postRequest);
        ICollection<PostDto> GetAllPosts();
        ICollection<PostDto> GetUserPosts(long userId);
        ICollection<PostDto> GetPostsFromTopic(long topicId);
        PostDto GetPost(long postId);
        bool UpdatePost(long postId, PostDto postRequest);
        bool DeletePost(long postId);
    }
}
