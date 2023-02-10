using BlogPostAPI.Models;

namespace BlogPostAPI.Interfaces.Repository
{
    public interface IUserRepository
    {
        bool CreateUser(User user);
        ICollection<User> GetAllUsers();
        User GetUser(long userId);
        bool UpdateUser(User User);
        bool DeleteUser(User user);
        bool UserExists(long userId);
        bool Save();
    } 
}
