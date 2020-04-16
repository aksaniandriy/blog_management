using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Database.Database;
using Blog.Database.Entities;

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
            throw new NotImplementedException();
        }

        public Task<Post> AddAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
