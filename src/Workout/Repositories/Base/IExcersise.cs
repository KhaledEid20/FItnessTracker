using System;
using Workout.DTOs;
using Workout.Models;

namespace Workout.Repositories.Base;

public interface IExcersise
{
    Task<ResultDto<string>> CreateExercise(ExerciseDTO createExerciseDTO);
    Task<ResultDto <string>> UpdateExercise(string id, ExerciseDTO createExerciseDTO);
    Task<ResultDto<string>> DeleteExercise(string id);
    Task<ResultDto<List<Exercise>>> GetAllExercises();
}
