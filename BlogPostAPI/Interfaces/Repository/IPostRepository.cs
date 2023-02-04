using BlogPostAPI.Models;

namespace BlogPostAPI.Interfaces.Repository
{
    public interface IPostRepository
    {
        bool CreatePost(Post Post);
        public bool Save();
        ICollection<Post> GetAllPosts();
        bool PostExists(long postId);

    }
}
