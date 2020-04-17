using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Database.Database;
using Blog.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Database.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _context;

        public PostRepository(BlogDbContext context)
        {
            _context = context;
        }

        public Task<Post> GetAsync(Guid id)
        {
            return _context.Posts
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Post> AddAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _context.Posts.OrderByDescending(x => x.CreatedUtc).ToListAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);

            _context.Remove(post);
            var affectedRows = await _context.SaveChangesAsync();

            return affectedRows > 0;
        }
    }
}
