using System;

namespace Workout.Models;

public class WorkoutExercise
{
    public Guid ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
    public Guid WorkoutId { get; set; }
    public WorkOut Workout { get; set; }
}
