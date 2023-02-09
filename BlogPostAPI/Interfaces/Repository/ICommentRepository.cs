﻿using BlogPostAPI.Models;

namespace BlogPostAPI.Interfaces.Repository
{
    public interface ICommentRepository
    {

        bool CreateComment(Comment Comment);
        ICollection<Comment> GetAllComments();
        ICollection<Comment> GetUserComments(long userId);
        ICollection<Comment> GetPostComments(long postId);
        Comment GetComment(long commentId);
        bool UpdateComment(Comment comment);
        bool DeleteComment(Comment comment);
        bool PostComment(Comment comment);

        public bool Save();


    }
}
