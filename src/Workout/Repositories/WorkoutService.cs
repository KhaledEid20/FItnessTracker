using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Workout.Data;
using Workout.DTOs;
using Workout.Models;
using Workout.Repositories.Base;

namespace Workout.Repositories
{
    public class WorkoutService : Base<WorkOut> , IWorkout
    {
        public WorkoutService(AppDbContext context , IHttpContextAccessor httpContextAccessor) : base(context , httpContextAccessor)
        {}

        public User _user { get; set; }
        public async Task<ResultDto> CreateWorkout(CreateWorkoutDto workout)
        {
            _user = await ValidateUser();
            if (_user == null)
            {
                return new ResultDto
                {
                    Message = "User not found",
                    Success = false
                };
            }
            try{
                var neWorkout = new WorkOut(){
                    UserId = _user.Id,
                    Title = workout.Title,
                    CreationDate = DateTime.Now,
                    EndDate = workout.EndDate,
                    Notes = workout.Notes
                };
                await _context.WorkOuts.AddAsync(neWorkout);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex){
                return new ResultDto
                {
                    Message = ex.Message,
                    Success = false
                };
            }
            return new ResultDto
            {
                Message = "Workout created successfully",
                Success = true
            };
        }
        public async Task<ResultDto> DeleteWorkout(WorkoutDto workoutId)
        {
            _user = await ValidateUser();
            if(_user == null)        
            {
                return new ResultDto
                {
                    Message = "User not found",
                    Success = false
                };
            }
            var workout = await _context.WorkOuts.FirstOrDefaultAsync(x => x.UserId == _user.Id && x.CreationDate == workoutId.CreationDate && x.Title == workoutId.Title);
            try{
                _context.Remove(workout);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex){
                return new ResultDto
                {
                    Message = ex.Message,
                    Success = false
                };
            }
            return new ResultDto
            {
                Message = "Workout deleted successfully",
                Success = true
            };
        }
        public async Task<ResultDto> UpdateWorkout(WorkoutDto workout)
        {
            _user = await ValidateUser();
            if(_user == null)        
            {
                return new ResultDto
                {
                    Message = "User not found",
                    Success = false
                };
            }
            var workoutToUpdate = await _context.WorkOuts
            .FirstOrDefaultAsync(x => x.UserId == _user.Id 
            && x.CreationDate == workout.CreationDate 
            && x.Title == workout.old_Title);
            try {
                workoutToUpdate.Title = workout.Title;
                workoutToUpdate.Notes = workout.Notes;
                if(workout.Finished == true){
                    workoutToUpdate.Finished = true;
                    workoutToUpdate.EndDate = DateTime.Now;
                }
                await _context.SaveChangesAsync();
            }
            catch(Exception ex){
                return new ResultDto
                {
                    Message = ex.Message,
                    Success = false
                };
            }
            return new ResultDto
            {
                Message = "Workout updated successfully",
                Success = true
            };

        }
    }
}