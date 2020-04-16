using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Database.Entities;

namespace Blog.Database.Repositories
{
    public interface IPostRepository
    {
        /// <summary>
        /// Get post by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Post> GetAsync(Guid id);

        /// <summary>
        /// Add post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Task<Post> AddAsync(Post post);

        /// <summary>
        /// Get all posts
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetAllAsync();

        /// <summary>
        /// Delete post
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(Guid id);
    }
}
