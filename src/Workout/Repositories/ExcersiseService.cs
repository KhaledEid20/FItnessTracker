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

    public async Task<ResultDto> CreateExercise(ExerciseDTO createExerciseDTO)
    {
        Exercise ex = new(){
            ExerciseName = createExerciseDTO.ExerciseName,
            TargetMuscle = createExerciseDTO.TargetMuscle,
            SecondaryMuscle = createExerciseDTO.SecondaryMuscle,
            Counts = createExerciseDTO.Counts,
            Groups = createExerciseDTO.Groups
        };
        try{
            await _context.Exercises.AddAsync(ex);
            await _context.SaveChangesAsync();

        }catch(Exception e)
        {
            return new ResultDto
            {
                Message = e.Message,
                Success = false
            };
        }
        return new ResultDto
        {
            Message = "Exercise Created",
            Success = true
        };
    } 

    public async Task<ResultDto> DeleteExercise(Guid id)
    {
        var ex = await _context.Exercises.FindAsync(id);
        if(ex == null)
        {
            return new ResultDto
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
            return new ResultDto
            {
                Message = e.Message,
                Success = false
            };
        }
        return new ResultDto
        {
            Message = "Exercise Deleted",
            Success = true
        };
    }

    public async Task<IEnumerable<Exercise>> GetAllExercises()
    {
        var exercises = await _context.Exercises.ToListAsync();
        if(exercises == null)
        {
            return null;
        }
        return exercises;
    }

    public async Task<ResultDto> UpdateExercise(Guid id, ExerciseDTO createExerciseDTO)
    {
        var exercise = await _context.Exercises.FindAsync(id);
        if(exercise == null)
        {
            return new ResultDto
            {
                Message = "Exercise not found",
                Success = false
            };
        }
        exercise.ExerciseName = createExerciseDTO.ExerciseName;
        exercise.TargetMuscle = createExerciseDTO.TargetMuscle;
        exercise.SecondaryMuscle = createExerciseDTO.SecondaryMuscle;
        exercise.Counts = createExerciseDTO.Counts;
        exercise.Groups = createExerciseDTO.Groups;
        try{
            _context.Exercises.Update(exercise);
            _context.SaveChanges();
        }catch(Exception e)
        {
            return new ResultDto
            {
                Message = e.Message,
                Success = false
            };
        }
        return new ResultDto
        {
            Message = "Exercise Updated",
            Success = true
        };
    }
}
