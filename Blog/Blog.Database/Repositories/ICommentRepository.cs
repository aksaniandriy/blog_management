using System;
using System.Threading.Tasks;
using Blog.Database.Entities;

namespace Blog.Database.Repositories
{
    public interface ICommentRepository
    {
        Task<bool> AnyAsync(Guid postId);
        Task<int> AddComment(Guid postId, Comment comment);
    }
}
