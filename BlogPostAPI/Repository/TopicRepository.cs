using BlogPostAPI.Data;
using BlogPostAPI.Interfaces.Repository;
using BlogPostAPI.Models;
using Microsoft.Extensions.Hosting;

namespace BlogPostAPI.Repository
{
    public class TopicRepository : ITopicRepository
    {
        private readonly DataContext _context;

        public TopicRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddTopicToPost(PostTopic postTopic)
        {
            _context.Add(postTopic);
            return Save();
        }

        public bool CreateTopic(Topic topic)
        {
            _context.Add(topic);
            return Save();
        }
        public bool DeleteTopic(Topic topic)
        {
            _context.Remove(topic);
            return Save();
        }

        public bool DeleteTopicFromPost(PostTopic postTopic)
        {
            _context.Remove(postTopic);
            return Save();
        }

        public ICollection<Topic> GetAllTopics()
        {
            ICollection<Topic> topics = _context.Topics.OrderBy(t => t.Id).ToList();
            return topics;
        }

        public ICollection<Topic> GetTopicsFromPost(long postId)
        {
            return _context.PostTopics.Where(pt => pt.Post.Id == postId).Select(pt => pt.Topic).ToList();
        }

        public Topic GetTopic(long topicId)
        {
            return _context.Topics.Where(t => t.Id == topicId).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges(); // TODO is var good to use?
            return saved > 0 ? true : false;
        }

        public bool TopicExists(long topicId)
        {
            return _context.Topics.Any(t => t.Id == topicId);

        }
        public bool UpdateTopic(Topic topic)
        {
            _context.Update(topic);
            return Save();
        }
    }
}
