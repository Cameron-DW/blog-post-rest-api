using AutoMapper;
using BlogPostAPI.Interfaces.Repository;
using BlogPostAPI.Interfaces.Services;
using BlogPostAPI.Models;
using BlogPostAPI.Models.Dto;
using BlogPostAPI.Repository;
using Microsoft.Identity.Client;

namespace BlogPostAPI.Service
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public TopicService(ITopicRepository topicRepository, IPostRepository postRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public bool CreateTopic(TopicDto topicRequest)
        {
            Topic topic = _mapper.Map<Topic>(topicRequest);
            return _topicRepository.CreateTopic(topic);
        }

        public bool AddTopicToPost(long postId, long topicId)
        {
            Post post = _postRepository.GetPost(postId);
            Topic topic = _topicRepository.GetTopic(topicId);
            var postTopic = new PostTopic()
            {
                Post = post,
                Topic = topic
            };
            return _topicRepository.AddTopicToPost(postTopic);
        }

        public ICollection<TopicDto> GetAllTopics()
        {
            ICollection<Topic> topics = _topicRepository.GetAllTopics();
            return _mapper.Map<ICollection<TopicDto>>(topics);
        }

        public ICollection<TopicDto> GetTopicsFromPost(long postId)
        {
            ICollection<Topic> topics = _topicRepository.GetTopicsFromPost(postId);
            return _mapper.Map<ICollection<TopicDto>>(topics);
        }

        public TopicDto GetTopic(long topicId)
        {
            Topic topic = _topicRepository.GetTopic(topicId);
            return _mapper.Map<TopicDto>(topic);
        }

        public bool UpdateTopic(long topicId, TopicDto topicRequest)
        {
            Topic topic = _mapper.Map<Topic>(topicRequest);
            return _topicRepository.UpdateTopic(topic);
        }

        public bool DeleteTopicFromPost(long postId, long topicId)
        {
            Post post = _postRepository.GetPost(postId);
            Topic topic = _topicRepository.GetTopic(topicId);
            var postTopic = new PostTopic()
            {
                Post = post,
                Topic = topic
            };
            return _topicRepository.DeleteTopicFromPost(postTopic);
        }

        public bool DeleteTopic(long topicId)
        {
            Topic topic = _topicRepository.GetTopic(topicId);
            return _topicRepository.DeleteTopic(topic);
        }
    }
}
