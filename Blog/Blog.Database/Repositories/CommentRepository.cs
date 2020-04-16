using System;
using System.Linq;
using System.Threading.Tasks;
using Blog.Database.Database;
using Blog.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Database.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogDbContext _context;

        public CommentRepository(BlogDbContext context)
        {
            _context = context;
        }

        public Task<bool> AnyAsync(Guid postId)
        {
            return _context.Comments.AnyAsync(x => x.PostId == postId);
        }

        public Task<int> AddComment(Guid postId, Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
