using BlogPostAPI.Data;
using BlogPostAPI.Interfaces.Repository;
using BlogPostAPI.Models;

namespace BlogPostAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateUser(User user)
        {
            _context.Add(user);
            return Save();
        }

        public ICollection<User> GetAllUsers()
        {
            var users = _context.Users.OrderBy(u => u.Id).ToList();
            return users;
        }

        public User GetUser(long userId)
        {
            User user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            return user;
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }

        public bool UserExists(long userId)
        {
            return _context.Users.Any(u => u.Id == userId);

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
