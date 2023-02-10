using BlogPostAPI.Models.Dto;

namespace BlogPostAPI.Interfaces.Services
{
    public interface ITopicService
    {
        bool CreateTopic(TopicDto topicRequest);
        bool AddTopicToPost(long postId, long topicId);
        ICollection<TopicDto> GetAllTopics();
        ICollection<TopicDto> GetTopicsFromPost(long postId); //  TODO do TopicPosts in IPostService too
        TopicDto GetTopic(long topicId);
        bool UpdateTopic(long topicId, TopicDto topicRequest);
        bool DeleteTopicFromPost(long postId, long topicId);
        bool DeleteTopic(long topicId);
    }
}
