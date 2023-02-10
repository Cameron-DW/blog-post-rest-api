using AutoMapper;
using BlogPostAPI.Interfaces.Services;
using BlogPostAPI.Models.Dto;
using BlogPostAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;

        public TopicController(ITopicService topicService, IMapper mapper)
        {
            _topicService = topicService;
            _mapper = mapper;
        }

        // Create Topic
        [HttpPost("topics")]
        public IActionResult CreateTopic([FromBody] TopicDto topicRequest)
        {
            if (!_topicService.CreateTopic(topicRequest))
                return BadRequest(ModelState);

            return Ok("Topic Created");
        }

        // Add Topic to Post
        [HttpPost("posts/{postId}/topics/{topicId}")]
        public IActionResult AddTopicToPost(long postId, long topicId)
        {
            if (!_topicService.AddTopicToPost(postId, topicId))
                return BadRequest();

            return Ok("Topic Added");
        }

        // Get All Topics
        [HttpGet("topics")]
        public IActionResult GetAllTopics()
        {
            ICollection<TopicDto> topics = _topicService.GetAllTopics();
            return Ok(topics);
        }

        // Get All Topics From Post
        [HttpGet("posts/{postId}/topics")]
        public IActionResult GetTopicsFromPost(long postId)
        {
            ICollection<TopicDto> topics = _topicService.GetTopicsFromPost(postId);
            return Ok(topics);
        }

        // Get Topic
        [HttpGet("topics/{topicId}")]
        public IActionResult GetTopic(long topicId)
        {
            TopicDto topic = _topicService.GetTopic(topicId);
            return Ok(topic);
        }

        // Update Topic
        [HttpPut("topics/{topicId}")]
        public IActionResult UpdateTopic(long topicId, [FromBody] TopicDto topicRequest)
        {
            if (!_topicService.UpdateTopic(topicId, topicRequest))
                return BadRequest();

            return Ok("Topic Updated");
        }

        // Delete Topic from Post
        [HttpDelete("posts/{postId}/topics/{topicId}")]
        public IActionResult DeleteTopicFromPost(long postId, long topicId)
        {
            if (!_topicService.DeleteTopicFromPost(postId, topicId))
                return BadRequest();

            return NoContent();
        }

        // Delete Topic
        [HttpDelete("topics/{topicId}")]
        public IActionResult DeleteTopic(long topicId)
        {
            if (!_topicService.DeleteTopic(topicId))
                return BadRequest();

            return NoContent();
        }
    }
}
