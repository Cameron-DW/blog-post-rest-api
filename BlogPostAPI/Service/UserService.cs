using AutoMapper;
using BlogPostAPI.Dto;
using BlogPostAPI.Interfaces.Repository;
using BlogPostAPI.Interfaces.Services;
using BlogPostAPI.Models;
using BlogPostAPI.Repository;

namespace BlogPostAPI.Service
{
    public class UserService : IUserService

    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public bool CreateUser(UserDto userRequest)
        {
            var user = _mapper.Map<User>(userRequest);
            return _userRepository.CreateUser(user);
        }

      

        public UserDto GetUser(long userId)
        {
            User user = _userRepository.GetUser(userId);
            return _mapper.Map<UserDto>(user);
        }


        public ICollection<UserDto> GetAllUsers()
        {   
            ICollection<User> users = _userRepository.GetAllUsers();
            return _mapper.Map<ICollection<UserDto>>(users);
        }

        public bool UpdateUser(long userId, UserDto userRequest)
        {
            var user = _mapper.Map<User>(userRequest);
            user.Id = userId;
            return _userRepository.UpdateUser(userId, user);
        }

        public bool DeleteUser(long userId)
        {
            User user = _userRepository.GetUser(userId);
            return _userRepository.DeleteUser( user);
        }
    }
}
