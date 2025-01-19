using System;

namespace Workout.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid WorkoutId { get; set; }
        public string Text { get; set; }

        // Navigation properties
        public User User { get; set; }
        public WorkOut workOut { get; set; }
    }
}
