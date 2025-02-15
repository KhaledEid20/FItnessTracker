using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Workout.DTOs;
using Workout.Models;

namespace Workout.Repositories.Base
{
    public interface IWorkout
    {
        Task<ResultDto<IEnumerable<GetWorkoutDTO>>> GetAllWorkouts();
        Task<ResultDto<string>> CreateWorkout(CreateWorkoutDto workout);
        Task<ResultDto<string>> UpdateWorkout(WorkoutDto workout , string workoutId);
        Task<ResultDto<string>> DeleteWorkout(string workoutId);
        Task<ResultDto<string>> AssignExerciseToWorkout(List<string> guids , string workoutId);
    }
}