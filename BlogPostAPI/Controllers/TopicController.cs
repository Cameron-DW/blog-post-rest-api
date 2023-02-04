using AutoMapper;
using BlogPostAPI.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;

        public TopicController(ITopicService topicService, IMapper mapper)
        {
            _topicService = topicService;
            _mapper = mapper;
        }
    }
}
