using BlogPostAPI.Models;
using BlogPostAPI.Models.Dto;

namespace BlogPostAPI.Interfaces.Services
{
    public interface IUserService
    {
        bool CreateUser(UserDto userRequest);
        ICollection<UserDto> GetAllUsers();
        UserDto GetUser(long userId);
        bool UpdateUser(long userId, UserDto userRequest);
        bool DeleteUser(long userId);
    }
}
