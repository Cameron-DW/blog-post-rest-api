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

        public ICollection<Post> GetUserPosts(long userId)
        {
            return _context.Posts.Where(p => p.User.Id == userId).ToList();
        }
        public ICollection<Post> GetPostsFromTopic(long topicId)
        {
            return _context.PostTopics.Where(pt => pt.Topic.Id == topicId).Select(pt => pt.Post).ToList();
        }

        public Post GetPost(long postId)
        {
            return _context.Posts.Where(p => p.Id == postId).FirstOrDefault();
        }

        public bool UpdatePost(Post post)
        {
            _context.Update(post);
            return Save();
        }

        public bool DeletePost(Post post)
        {
            _context.Remove(post);
            return Save();
        }

        public bool PostExists(long postId)
        {
            return _context.Posts.Any(p => p.Id == postId);

        }

        public bool Save()
        {
            var saved = _context.SaveChanges(); // TODO is var good to use?
            return saved > 0 ? true : false;
        }
    }
}
