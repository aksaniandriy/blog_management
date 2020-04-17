using System;
using System.Threading.Tasks;
using Blog.Services.Models;

namespace Blog.Services.Interfaces
{
    public interface ICommentService
    {
        /// <summary>
        /// Add comment for a post
        /// </summary>
        /// <param name="postId">Post id</param>
        /// <param name="comment"></param>
        /// <returns>Comment Id</returns>
        Task<OperationResult<int>> AddAsync(Guid postId, CommentDto comment);
    }
}
