using System;
using Workout.Data;
using Workout.Models;
using Workout.Repositories.Base;

namespace Workout.Repositories;

public class CommentsService : Base<Comment> , IComments
{
    public CommentsService(AppDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
    {
    }
}
