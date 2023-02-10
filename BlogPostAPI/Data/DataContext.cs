using BlogPostAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BlogPostAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTopic> PostTopics { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PostTopic>()
                .HasKey(pt => new { pt.PostId, pt.TopicId });
            builder.Entity<PostTopic>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTopics)
                .HasForeignKey(pt => pt.PostId);
            builder.Entity<PostTopic>()
                .HasOne(pt => pt.Topic)
                .WithMany(t => t.PostTopics)
                .HasForeignKey(pt => pt.TopicId);
        }
    }
}
