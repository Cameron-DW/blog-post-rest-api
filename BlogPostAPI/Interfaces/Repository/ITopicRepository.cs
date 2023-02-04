namespace BlogPostAPI.Interfaces.Repository
{
    public interface ITopicRepository
    {
        public bool Save();
        bool TopicExists(long topicId);

    }
}
