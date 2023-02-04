namespace BlogPostAPI.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        ICollection<Post> Posts { get; set; }
        ICollection<Comment> Comments { get; set; }

    }
}
