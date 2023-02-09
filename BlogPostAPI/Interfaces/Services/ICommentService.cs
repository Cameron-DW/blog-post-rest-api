
using BlogPostAPI.Models.Dto;

namespace BlogPostAPI.Interfaces.Services
{
    public interface ICommentService
    {
        bool CreateComment(long userId, long postId, CommentDto commentRequest);
        ICollection<CommentDto> GetAllComments();
        ICollection<CommentDto> GetUserComments(long userId);
        ICollection<CommentDto> GetPostComments(long postId);
        CommentDto GetComment(long commentId);
        bool UpdateComment(long commentId, CommentDto commentRequest);
        bool DeleteComment(long commentId);
    }
}
