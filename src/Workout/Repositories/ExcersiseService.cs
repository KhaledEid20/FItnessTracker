using System;
using Microsoft.EntityFrameworkCore;
using Workout.Data;
using Workout.DTOs;
using Workout.Models;
using Workout.Repositories.Base;

namespace Workout.Repositories;

public class ExcersiseService : Base<Exercise>,IExcersise
{
    public ExcersiseService(AppDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
    {
    }

    public async Task<ResultDto<string>> CreateExercise(ExerciseDTO EX)
    {
        var ex = new Exercise(){
            ExerciseName = EX.ExerciseName,
            TargetMuscle = EX.TargetMuscle,
            SecondaryMuscle = EX.SecondaryMuscle,
            Counts = EX.Counts,
            Groups = EX.Groups
        };
        try{
            await _context.Exercises.AddAsync(ex);
            await _context.SaveChangesAsync();

        }catch(Exception e)
        {
            return new ResultDto<string>()
            {
                Message = e.Message,
                Success = false
            };
        }
        return new ResultDto<string>()
        {
            Message = "Exercise Created",
            Success = true
        };
    } 

    public async Task<ResultDto<string>> DeleteExercise(Guid id)
    {
        var ex = await _context.Exercises.FindAsync(id);
        if(ex == null)
        {
            return new ResultDto<string>()
            {
                Message = "Exercise not found",
                Success = false
            };
        }
        try{
            _context.Exercises.Remove(ex);
            await _context.SaveChangesAsync();
        }catch(Exception e)
        {
            return new ResultDto<string>()
            {
                Message = e.Message,
                Success = false
            };
        }
        return new ResultDto<string>()
        {
            Message = "Exercise Deleted",
            Success = true
        };
    }


    public async Task<ResultDto<string>> UpdateExercise(Guid id, ExerciseDTO EX)
    {
        var exercise = await _context.Exercises.FindAsync(id);
        if(exercise == null)
        {
            return new ResultDto<string>()
            {
                Message = "Exercise not found",
                Success = false
            };
        }
        exercise.ExerciseName = EX.ExerciseName;
        exercise.TargetMuscle = EX.TargetMuscle;
        exercise.SecondaryMuscle = EX.SecondaryMuscle;
        exercise.Counts = EX.Counts;
        exercise.Groups = EX.Groups;
        try{
            _context.Exercises.Update(exercise);
            _context.SaveChanges();
        }catch(Exception e)
        {
            return new ResultDto<string>()
            {
                Message = e.Message,
                Success = false
            };
        }
        return new ResultDto<string>()
        {
            Message = "Exercise Updated",
            Success = true
        };
    }

    public async Task<ResultDto<List<Exercise>>> GetAllExercises()
    {
        var exercises = await _context.Exercises.ToListAsync();
        if(exercises == null)
        {
            return null;
        }
        return new ResultDto<List<Exercise>>()
        {
            Data = exercises,
            Success = true
        };
    }
}
