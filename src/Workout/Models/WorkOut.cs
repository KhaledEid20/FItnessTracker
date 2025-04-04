using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Workout.Models
{
    public class WorkOut
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Finished { get; set; } = false;
        public Status Status { get; set; } = Status.Pending;
        public string Notes { get; set; }
        public User user { get; set; }
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; } =  new List<WorkoutExercise>();
        public ICollection<Comment> Comments { get; set; }
    }
}