using BlogPostAPI.Models;

namespace BlogPostAPI.Interfaces.Repository
{
    public interface IPostRepository
    {
        bool CreatePost(Post Post);
        public bool Save();
        ICollection<Post> GetAllPosts();
        ICollection<Post> GetUserPosts(long userId);
        Post GetPost(long postId);
        bool UpdatePost(Post post);
        bool DeletePost(Post post);
        bool PostExists(long postId);



    }
}
