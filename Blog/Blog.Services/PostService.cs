using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Common.Exceptions;
using Blog.Database.Entities;
using Blog.Database.Repositories;
using Blog.Services.Interfaces;
using Blog.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Blog.Services
{
    public class PostService : IPostService
    {
        private readonly ILogger<PostService> _logger;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public PostService(IPostRepository postRepository, 
            ICommentRepository commentRepository, 
            IMapper mapper, 
            ILogger<PostService> logger)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OperationResult<PostDto>> GetAsync(Guid id)
        {
            var post = await GetPost(id);

            return OperationResult<PostDto>.CreateSuccessResult(_mapper.Map<PostDto>(post));
        }

        public async Task<OperationResult<PostDto>> AddAsync(PostDto post)
        {
            try
            {
                var response = await _postRepository.AddAsync(_mapper.Map<Post>(post));
                return OperationResult<PostDto>.CreateSuccessResult(_mapper.Map<PostDto>(response));
            }
            catch (DbUpdateException)
            {
                return OperationResult<PostDto>.CreateFailure("Could not create a post");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured: {ex.Message}");
                throw new BlogException(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public async Task<OperationResult<IEnumerable<PostDto>>> GetAllAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return OperationResult<IEnumerable<PostDto>>.CreateSuccessResult(_mapper.Map<IEnumerable<PostDto>>(posts));
        }

        public async Task<OperationResult<bool>> DeleteAsync(Guid id)
        {
            var post = await GetPost(id);
            var hasComments = await _commentRepository.AnyAsync(post.Id);

            if (hasComments)
                return OperationResult<bool>.CreateFailure("Post cannot be deleted");

            try
            {
                await _postRepository.DeleteAsync(id);
                return OperationResult<bool>.CreateSuccessResult(true);
            }
            catch (DbUpdateException)
            {
                return OperationResult<bool>.CreateFailure("Could not delete the post");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured: {ex.Message}");
                throw new BlogException(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        private async Task<Post> GetPost(Guid id)
        {
            var post = await _postRepository.GetAsync(id);
            if (post == null)
            {
                _logger.LogError($"Could not find blog post with id={id} in the DB");
                throw new BlogException(HttpStatusCode.NotFound, "Blog post was not found in the database");
            }

            return post;
        }
    }
}
