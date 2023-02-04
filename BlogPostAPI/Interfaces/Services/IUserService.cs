using BlogPostAPI.Dto;
using BlogPostAPI.Models;

namespace BlogPostAPI.Interfaces.Services
{
    public interface IUserService
    {
        bool CreateUser(UserDto UserRequest);
        ICollection<UserDto> GetAllUsers();
        UserDto GetUser(long userId);
        bool UpdateUser(long userId, UserDto UserRequest);
        bool DeleteUser(long userId);

    }
}
