namespace BlogPostAPI.Models
{
    public class Topic
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<PostTopic> PostTopics { get; set; }
    }
}
