using System;
using Workout.DTOs;
using Workout.Models;

namespace Workout.Repositories.Base;

public interface IExcersise
{
    Task<ResultDto> CreateExercise(ExerciseDTO createExerciseDTO);
    Task<ResultDto> UpdateExercise(Guid id, ExerciseDTO createExerciseDTO);
    Task<ResultDto> DeleteExercise(Guid id);
    Task<IEnumerable<Exercise>> GetAllExercises();
}
