using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Api.Models;
using Blog.Services.Interfaces;
using Blog.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Blog.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/posts")]
    public class PostController : ControllerBase 
    {
        private readonly ILogger<PostController> _logger;
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(ILogger<PostController> logger, ICommentService commentService, IPostService postService, IMapper mapper)
        {
            _logger = logger;
            _commentService = commentService;
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet("{postId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult<PostDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPost([FromRoute]Guid postId)
        {
            _logger.LogDebug($"GetPost called with {nameof(postId)}={postId}");
            
            return Ok(await _postService.GetAsync(postId));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult<IEnumerable<PostDto>>))]
        public async Task<IActionResult> GetAllPosts()
        {
            _logger.LogDebug("GetAllPosts called");
            
            return Ok(await _postService.GetAllAsync());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult<PostDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreatePost([FromBody]CreatePostRequest request)
        {
            _logger.LogDebug($"CreatePost called with CreatePostRequest={JsonConvert.SerializeObject(request)}");

            var dto = new PostDto(request.Title, request.Text);
            var result = await _postService.AddAsync(dto);

            if (!result.Success)
                return BadRequest(result.FailureMessage);

            return Ok(result);
        }

        [HttpPost("{postId:guid}/comment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResult<int>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddComment([FromRoute]Guid postId, [FromBody]CreateCommentRequest request)
        {
            _logger.LogDebug($"AddComment called for post {postId} with request: {JsonConvert.SerializeObject(request)}");

            var dto = new CommentDto(request.Text);
            var result = await _commentService.AddAsync(postId, dto);

            if (!result.Success)
                return BadRequest(result.FailureMessage);

            return Ok(result);
        }

        [HttpDelete("{postId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePost([FromRoute]Guid postId)
        {
            _logger.LogDebug($"DeletePost called with postId={postId}");
            
            var result = await _postService.DeleteAsync(postId);

            if (!result.Success)
                return BadRequest(result.FailureMessage);

            return Ok(result);
        }
    }
}
