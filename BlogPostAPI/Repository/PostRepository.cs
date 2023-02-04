using BlogPostAPI.Data;
using BlogPostAPI.Interfaces.Repository;
using BlogPostAPI.Models;

namespace BlogPostAPI.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;

        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreatePost(Post Post)
        {
            _context.Add(Post);
            return Save();
        }

        public ICollection<Post> GetAllPosts()
        {
           ICollection<Post> posts = _context.Posts.OrderBy(p => p.Id).ToList();
            return posts;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges(); // TODO is var good to use?
            return saved > 0 ? true : false;
        }

        public bool PostExists(long postId)
        {
            return _context.Posts.Any(p => p.Id == postId);

        }


    }
}
