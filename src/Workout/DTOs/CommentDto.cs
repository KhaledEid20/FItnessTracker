using System;

namespace Workout.DTOs;

public class CommentDto
{
    public string Content { get; set; }
    public string UserId { get; set; }
    public string WorkoutId { get; set; }
}
