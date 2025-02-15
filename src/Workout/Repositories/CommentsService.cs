using System;
using Workout.Data;
using Workout.DTOs;
using Workout.Models;
using Workout.Repositories.Base;

namespace Workout.Repositories;

public class CommentsService : Base<Comment> , IComments
{
    public CommentsService(AppDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
    {
    }

    public Task<Comment> CreateCommentAsync(CommentDto commentDTO)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> DeleteCommentAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Comment>> GetAllCommentsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Comment> GetCommentByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> UpdateCommentAsync(Guid id, CommentDto commentDTO)
    {
        throw new NotImplementedException();
    }
}
