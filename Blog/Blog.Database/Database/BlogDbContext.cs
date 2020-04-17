using System;
using System.Threading;
using System.Threading.Tasks;
using Blog.Database.Configuration;
using Blog.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Blog.Database.Database
{
    public class BlogDbContext : DbContextBase<BlogDbContext>
    {
        private readonly ILogger<BlogDbContext> _logger;
        
        public BlogDbContext(DbContextOptions<BlogDbContext> options, ILogger<BlogDbContext> logger) : base(options)
        {
            _logger = logger;
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            PostConfiguration.Configure(builder.Entity<Post>());
            CommentConfiguration.Configure(builder.Entity<Comment>());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError($"DB error occured: {ex.Message}");
                throw;
            }
        }
    }
}
