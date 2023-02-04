namespace BlogPostAPI.Interfaces.Repository
{
    public interface ICommentRepository
    {
        public bool Save();
        bool CommentExists(long commentId);

    }
}
