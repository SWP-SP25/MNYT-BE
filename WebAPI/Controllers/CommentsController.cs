﻿using Application.Utils.Implementation;
using Microsoft.AspNetCore.Mvc;
using Application.ViewModels.Blog;
using Application.IServices;
using Application.ViewModels;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int accountId, [FromBody] CreateCommentDTO dto)
        {
            var comment = await _commentService.AddCommentAsync(accountId, dto);
            if (comment == null)
            {
                return NotFound(ApiResponse<ReadCommentDTO>.FailureResponse("Cannot add comment; post not found."));
            }
            return Ok(ApiResponse<ReadCommentDTO>.SuccessResponse(comment, "Comment added."));
        }

        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetCommentsByPost(int postId, [FromQuery] QueryParameters query)
        {
            var comments = await _commentService.GetCommentsByPostAsync(postId, query);
            return Ok(ApiResponse<PaginatedList<ReadCommentDTO>>.SuccessResponse(comments, "Comments retrieved."));
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId, int accountId)
        {
            var success = await _commentService.DeleteCommentAsync(commentId, accountId);
            if (!success)
            {
                return NotFound(ApiResponse<string>.FailureResponse("Could not delete comment. Possibly not found or no permission."));
            }
            return Ok(ApiResponse<string>.SuccessResponse("Comment deleted."));
        }
    }
}
