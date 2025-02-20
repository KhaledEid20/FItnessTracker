using System;

namespace Workout.DTOs;

public class CommentDto
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string Text { get; set; }
    public string WorkoutId { get; set; }
}
