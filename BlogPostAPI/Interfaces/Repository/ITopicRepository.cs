using BlogPostAPI.Models;

namespace BlogPostAPI.Interfaces.Repository
{
    public interface ITopicRepository
    {
        bool CreateTopic(Topic topic);
        bool AddTopicToPost(PostTopic postTopic);
        ICollection<Topic> GetAllTopics();
        ICollection<Topic> GetTopicsFromPost(long postId);
        Topic GetTopic(long topicId);
        bool UpdateTopic(Topic topic);
        bool DeleteTopicFromPost(PostTopic postTopic);
        bool DeleteTopic(Topic topic);
        bool TopicExists(long topicId);
        public bool Save();
    }
}
