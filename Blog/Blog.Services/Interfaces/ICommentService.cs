using System;
using System.Threading.Tasks;
using Blog.Domain.Models;

namespace Blog.Services.Interfaces
{
    public interface ICommentService
    {
        /// <summary>
        /// Add comment for a post
        /// </summary>
        /// <param name="postId">Post id</param>
        /// <param name="comment"></param>
        /// <returns></returns>
        Task AddAsync(Guid postId, CommentDto comment);
    }
}
