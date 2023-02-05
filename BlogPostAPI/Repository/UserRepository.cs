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
            return Save(); // TODO, does returning save execute the save function e.g. if there was a console.log in save, would it execute this? YES i think so
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }

        public User GetUser(long userId)
        {
            User user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            return user;
        }

        public ICollection<User> GetAllUsers()
        {
            var users = _context.Users.OrderBy(u => u.Id).ToList();
            return users;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges(); // TODO is var good to use?
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool UserExists(long userId)
        {
            return _context.Users.Any(u => u.Id == userId);

        }
    }
}
