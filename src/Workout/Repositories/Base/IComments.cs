using System;
using Workout.DTOs;
using Workout.Models;

namespace Workout.Repositories.Base;

public interface IComments
{
    Task<ResultDto<IEnumerable<CommentDto>>> GetAllCommentsAsync(string WorkoutId);
    Task<ResultDto<CommentDto>> GetCommentByIdAsync(string id);
    Task<ResultDto<string>> CreateCommentAsync(CommentDto commentDTO);
    Task<ResultDto<string>> UpdateCommentAsync(string id, CommentDto commentDTO);
    Task<ResultDto<string>> DeleteCommentAsync(string id);
}   