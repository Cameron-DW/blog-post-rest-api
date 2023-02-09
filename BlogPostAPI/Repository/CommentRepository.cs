using BlogPostAPI.Data;
using BlogPostAPI.Interfaces.Repository;
using BlogPostAPI.Models;
using Microsoft.Extensions.Hosting;

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

        public bool CreateComment(Comment Comment)
        {
            _context.Add(Comment);
            return Save();

        }

        public ICollection<Comment> GetAllComments()
        {
            ICollection<Comment> comments = _context.Comments.OrderBy(c => c.Id).ToList();
            return comments;
        }

        public ICollection<Comment> GetUserComments(long userId)
        {
            return _context.Comments.Where(c => c.User.Id == userId).ToList();
        }

        public ICollection<Comment> GetPostComments(long postId)
        {
            return _context.Comments.Where(c => c.Post.Id == postId).ToList();
        }

        public Comment GetComment(long commentId)
        {
            return _context.Comments.Where(c => c.Id == commentId).FirstOrDefault();
        }

        public bool UpdateComment(Comment comment)
        {
            _context.Update(comment);
            return Save();
        }

        public bool DeleteComment(Comment comment)
        {
            _context.Remove(comment);
            return Save();
        }

        public bool PostComment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
