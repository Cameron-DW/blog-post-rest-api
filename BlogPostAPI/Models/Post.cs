namespace BlogPostAPI.Models
{
    public class Post
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set;}
        public ICollection<PostTopic> PostTopics { get; set;}

    }
}
