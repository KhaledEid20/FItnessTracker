using System;

namespace Workout.DTOs;

public class CreateWorkoutWithExcersises
{
    public CreateWorkoutDto workout { get; set; }
    public List<string> guids { get; set; }
}
