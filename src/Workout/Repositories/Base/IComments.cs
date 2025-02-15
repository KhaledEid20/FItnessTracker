using System;
using Workout.DTOs;
using Workout.Models;

namespace Workout.Repositories.Base;

public interface IComments
{
    Task<IEnumerable<Comment>> GetAllCommentsAsync();
    Task<Comment> GetCommentByIdAsync(Guid id);
    Task<Comment> CreateCommentAsync(CommentDto commentDTO);
    Task<Comment> UpdateCommentAsync(Guid id, CommentDto commentDTO);
    Task<Comment> DeleteCommentAsync(Guid id);
}