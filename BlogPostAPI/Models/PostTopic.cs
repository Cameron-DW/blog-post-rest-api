namespace BlogPostAPI.Models
{
    public class PostTopic
    {
        public long PostId { get; set; }
        public long TopicId { get; set; }
        public Post Post { get; set; }
        public Topic Topic { get; set; }
    }
}
