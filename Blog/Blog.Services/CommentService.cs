using System;
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
    public class CommentService : ICommentService
    {
        private readonly ILogger<CommentService> _logger;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, ILogger<CommentService> logger, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<OperationResult<int>> AddAsync(Guid postId, CommentDto comment)
        {
            try
            {
                var commentEntity = _mapper.Map<Comment>(comment);
                var commentId = await _commentRepository.AddComment(postId, commentEntity);
                return OperationResult<int>.CreateSuccessResult(commentId);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.Message);
                throw new BlogException(HttpStatusCode.NotFound, ex.Message);
            }
            catch (DbUpdateException)
            {
                throw new BlogException(HttpStatusCode.BadRequest, "Could not add a comment");
            }
        }
    }
}
