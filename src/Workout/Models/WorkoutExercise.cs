using System;

namespace Workout.Models;

public class WorkoutExercise
{
    public string ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
    public string WorkoutId { get; set; }
    public WorkOut Workout { get; set; }
}
