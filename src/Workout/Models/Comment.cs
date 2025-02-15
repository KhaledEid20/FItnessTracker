using System;

namespace Workout.Models
{
    public class Comment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string WorkoutId { get; set; }
        public string Text { get; set; }

        // Navigation properties
        public ICollection<Usercomment> comments { get; set; }
        public WorkOut workOut { get; set; }
    }
}
