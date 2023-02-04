using BlogPostAPI.Data;
using BlogPostAPI.Interfaces.Repository;

namespace BlogPostAPI.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _context;

        public CommentRepository(DataContext context)
        {
            _context = context;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges(); // TODO is var good to use?
            return saved > 0 ? true : false;
        }

        public bool CommentExists(long commentId)
        {
            return _context.Comments.Any(c => c.Id == commentId);

        }
    }
}
