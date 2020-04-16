using Blog.Database.Configuration;
using Blog.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Database.Database
{
    public class BlogDbContext : DbContextBase<BlogDbContext>
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            PostConfiguration.Configure(builder.Entity<Post>());
            CommentConfiguration.Configure(builder.Entity<Comment>());
        }
    }
}
