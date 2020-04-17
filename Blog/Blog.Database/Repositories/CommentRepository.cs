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

        /// <summary>
        /// Add comment to a post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="comment"></param>
        /// <returns>Comment id</returns>
        public async Task<int> AddComment(Guid postId, Comment comment)
        {
            var post = await _context.Posts.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id.Equals(postId));
            if (post == null)
            {
                throw new InvalidOperationException("The post doesn't exist in the DB");
            }

            post.Comments.Add(comment);
            _context.Entry(post).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return comment.Id;
        }
    }
}
