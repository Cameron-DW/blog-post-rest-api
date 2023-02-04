using BlogPostAPI.Data;
using BlogPostAPI.Interfaces.Repository;

namespace BlogPostAPI.Repository
{
    public class TopicRepository : ITopicRepository
    {
        private readonly DataContext _context;

        public TopicRepository(DataContext context)
        {
            _context = context;
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
    }
}
