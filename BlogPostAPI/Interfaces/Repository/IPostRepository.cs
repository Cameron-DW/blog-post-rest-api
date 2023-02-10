using BlogPostAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPostAPI.Interfaces.Repository
{
    public interface IPostRepository
    {
        bool CreatePost(Post post);
        ICollection<Post> GetAllPosts();
        ICollection<Post> GetUserPosts(long userId);
        public ICollection<Post> GetPostsFromTopic(long topicId);
        Post GetPost(long postId);
        bool UpdatePost(Post post);
        bool DeletePost(Post post);
        bool PostExists(long postId);
        public bool Save();
    }
}
