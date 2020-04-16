using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Services.Models;

namespace Blog.Services.Interfaces
{
    public interface IPostService
    {
        /// <summary>
        /// Get post by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResult<PostDto>> GetAsync(Guid id);

        /// <summary>
        /// Add post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Task<OperationResult<PostDto>> AddAsync(PostDto post);

        /// <summary>
        /// Get all posts
        /// </summary>
        /// <returns></returns>
        Task<OperationResult<IEnumerable<PostDto>>> GetAllAsync();

        /// <summary>
        /// Delete post
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns></returns>
        Task<OperationResult<bool>> DeleteAsync(Guid id);
    }
}
