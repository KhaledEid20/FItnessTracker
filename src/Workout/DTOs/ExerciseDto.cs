using System;

namespace Workout.DTOs;

public class ExerciseDTO
{
        public string ExerciseName { get; set; }
        public string TargetMuscle { get; set; }
        public string SecondaryMuscle { get; set; }
        public int Counts { get; set; }
        public int Groups { get; set; }
}
