using System;
using System.Threading.Tasks;
using Blog.Domain.Models;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class CommentService : ICommentService
    {
        public Task AddAsync(Guid postId, CommentDto comment)
        {
            throw new NotImplementedException();
        }
    }
}
