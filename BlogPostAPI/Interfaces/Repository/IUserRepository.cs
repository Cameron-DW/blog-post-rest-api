using BlogPostAPI.Models;

namespace BlogPostAPI.Interfaces.Repository
{
    public interface IUserRepository
    {
        bool CreateUser(User user);
        bool Save();
        User GetUser(long userId);
        ICollection<User> GetAllUsers();
        bool UpdateUser(User User);
        bool DeleteUser(User user);
        bool UserExists(long userId);
    } 
}
