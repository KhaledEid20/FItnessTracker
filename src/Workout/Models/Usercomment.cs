using System;

namespace Workout.Models;

public class Usercomment
{
    public string UserId { get; set; }
    public string CommentId { get; set; }
    public User user { get; set; }
    public Comment comment { get; set; }

}
