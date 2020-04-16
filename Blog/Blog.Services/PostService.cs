using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Database.Entities;
using Blog.Database.Repositories;
using Blog.Services.Interfaces;
using Blog.Services.Models;

namespace Blog.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private IMapper _mapper;
        public PostService(IPostRepository postRepository, ICommentRepository commentRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<PostDto>> GetAsync(Guid id)
        {
            var post = await _postRepository.GetAsync(id);
            return OperationResult<PostDto>.CreateSuccessResult(_mapper.Map<PostDto>(post));
        }

        public async Task<OperationResult<PostDto>> AddAsync(PostDto post)
        {
            var response = await _postRepository.AddAsync(_mapper.Map<Post>(post));
            return OperationResult<PostDto>.CreateSuccessResult(_mapper.Map<PostDto>(response));
        }

        public async Task<OperationResult<IEnumerable<PostDto>>> GetAllAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return OperationResult<IEnumerable<PostDto>>.CreateSuccessResult(_mapper.Map<IEnumerable<PostDto>>(posts));
        }

        public async Task<OperationResult<bool>> DeleteAsync(Guid id)
        {
            var hasComments = await _commentRepository.AnyAsync(id);

            if (!hasComments)
                return OperationResult<bool>.CreateFailure("Post has comments");

            await _postRepository.DeleteAsync(id);
            return OperationResult<bool>.CreateSuccessResult(true);
        }
    }
}
