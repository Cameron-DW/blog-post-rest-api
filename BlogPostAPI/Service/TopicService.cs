using AutoMapper;
using BlogPostAPI.Interfaces.Repository;
using BlogPostAPI.Interfaces.Services;

namespace BlogPostAPI.Service
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;

        public TopicService(ITopicRepository topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }
    }
}
