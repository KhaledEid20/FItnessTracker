using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Workout.Data;
using Workout.DTOs;
using Workout.Models;
using Workout.Repositories.Base;

namespace Workout.Repositories;

public class CommentsService : Base<Comment> , IComments
{
    public User _user { get; set; }
    public IMapper _mapper { get; set; }
    public CommentsService(AppDbContext context, IHttpContextAccessor httpContextAccessor , IMapper mapper) : base(context, httpContextAccessor)
    {
        _mapper = mapper;
    }

    public async Task<ResultDto<string>> CreateCommentAsync(CommentDto commentDTO)
    {
        _user = await ValidateUser();
        if(_user == null){
            return new ResultDto<string>{
                Message = "The user does not exist",
                Success = false
            };
        }
        try{
            Comment comment = new Comment{
                UserId = _user.Id,
                WorkoutId = commentDTO.WorkoutId,
                Text = commentDTO.Text
            };
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

        }catch(Exception ex){
            return new ResultDto<string>{
                Message = ex.Message,
                Success = false,
            };
        }
        return new ResultDto<string>{
            Message = "Comment published",
            Success = true
        };
    
    }

    public async Task<ResultDto<string>> DeleteCommentAsync(string id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        if(comment == null){
            return new ResultDto<string>(){
                Message = "The comment does not exist",
                Success = false
            };
        }
        try{
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            return new ResultDto<string>{
                Message = ex.Message,
                Success = false
            };
        }
        return new ResultDto<string>{
            Message = "The comment Deleted",
            Success = true
        };
    }

    public async Task<ResultDto<IEnumerable<CommentDto>>> GetAllCommentsAsync(string WorkoutId)
    {
        var comments = await _context.Comments.Where(x => x.WorkoutId == WorkoutId).ToListAsync();
        if(comments == null){
            return new ResultDto<IEnumerable<CommentDto>>(){
                Message = "There are no comments",
                Success = false
            };
        }
        IEnumerable<CommentDto> commentsDto = _mapper.Map<IEnumerable<CommentDto>>(comments);
        if(commentsDto == null){
            return new ResultDto<IEnumerable<CommentDto>>(){
                Message = "Error on mapping",
                Success = false
            };
        }
        return new ResultDto<IEnumerable<CommentDto>>(){
            Message = "The comments",
            Success = true,
            Data = commentsDto
        };

    }

    public async Task<ResultDto<CommentDto>> GetCommentByIdAsync(string id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        if(comment == null){
            return null;
        }
        CommentDto commentDto = _mapper.Map<CommentDto>(comment);
        if(commentDto == null){
            return new ResultDto<CommentDto>(){
                Message = "Error on mapping",
                Success = false
            };
        }
        return new ResultDto<CommentDto>(){
            Message = "The comment",
            Success = true,
            Data = commentDto
        };
    }

    public async Task<ResultDto<string>> UpdateCommentAsync(string id, CommentDto commentDTO)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        if(comment == null){
            return new ResultDto<string>(){
                Message = "The comment does not exist",
                Success = false
            };
        }
        try{
            comment.Text = commentDTO.Text;
            await _context.SaveChangesAsync();
        }
        catch(Exception ex){
            return new ResultDto<string>{
                Message = ex.Message,
                Success = false
            };
        }
        return new ResultDto<string>{
            Message = "The comment updated",
            Success = true
        };
    }
}
