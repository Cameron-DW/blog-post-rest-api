using BlogPostAPI.Models;

namespace BlogPostAPI.Interfaces.Repository
{
    public interface IUserRepository
    {
        bool CreateUser(User User);
        bool Save();
        User GetUser(long userId);
        ICollection<User> GetAllUsers();
        bool UpdateUser(long userId, User User);
        bool DeleteUser(User user);
        bool UserExists(long userId);
    } 
}
