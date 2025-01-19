using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workout.Models
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public Guid WorkoutId { get; set; }
        public string ExerciseName { get; set; }
        public string TargetMuscle { get; set; }
        public string SecondaryMuscle { get; set; }
        public int Counts { get; set; }
        public int Groups { get; set; }
        public WorkOut workOut { get; set; }
        public User user { get; set; }
    }
}