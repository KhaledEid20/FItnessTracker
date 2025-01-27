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
        Task<ResultDto> CreateWorkout(CreateWorkoutDto workout);
        Task<ResultDto> UpdateWorkout(WorkoutDto workout);
        Task<ResultDto> DeleteWorkout(WorkoutDto workoutDTO);
    }
}