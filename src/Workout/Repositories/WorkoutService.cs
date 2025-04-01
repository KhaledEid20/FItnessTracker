using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Workout.Data;
using Workout.DTOs;
using Workout.Models;
using Workout.Repositories.Base;

namespace Workout.Repositories
{
    public class WorkoutService : Base<WorkOut> , IWorkout
    {
        public IMapper _mapper { get; set; }
        public WorkoutService(AppDbContext context , IHttpContextAccessor httpContextAccessor , IMapper mapper) : base(context , httpContextAccessor)
        {
            _mapper = mapper;
        }

        public User _user { get; set; }

        public async Task<ResultDto<string>> CreateWorkout(CreateWorkoutWithExcersises workout)
        {
            _user = await ValidateUser();
            if (_user == null)
            {
                return new ResultDto<string>()
                {
                    Message = "User not found",
                    Success = false
                };
            }
            using(var transaction = _context.Database.BeginTransaction()){
                try{
                    var neWorkout = new WorkOut(){
                        UserId = _user.Id,
                        Title = workout.workout.Title,
                        CreationDate = DateTime.Now,
                        EndDate = workout.workout.EndDate,
                        Notes = workout.workout.Notes
                    };
                    await _context.WorkOuts.AddAsync(neWorkout);
                    await _context.SaveChangesAsync();
                    if(workout.guids != null){
                        List<WorkoutExercise> elements = new List<WorkoutExercise>();
                        foreach(var guid in workout.guids){
                            elements.Add(new WorkoutExercise{
                                WorkoutId = neWorkout.Id,
                                ExerciseId = guid
                            });
                        }
                        await _context.WorkoutExercises.AddRangeAsync(elements);
                        await _context.SaveChangesAsync();
                    }
                    transaction.Commit();
                }
                catch(Exception ex){
                    transaction.Rollback();
                    return new ResultDto<string>()
                    {
                        Message = ex.Message,
                        Success = false
                    };
                }
            }
            return new ResultDto<string>()
            {
                Message = "Workout created successfully",
                Success = true
            };
        }
        public async Task<ResultDto<string>> DeleteWorkout(string workoutId)
        {
            var workout = await _context.WorkOuts.FirstOrDefaultAsync(w=> w.Id == workoutId);
            if(workout == null){
                return new ResultDto<string>()
                {
                    Message = "Workout not found",
                    Success = false
                };
            }
            try{
                _context.Remove(workout);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex){
                return new ResultDto<string>()
                {
                    Message = ex.Message,
                    Success = false
                };
            }
            return new ResultDto<string>()
            {
                Message = "Workout deleted successfully",
                Success = true
            };
        }
        public async Task<ResultDto<string>> UpdateWorkout(WorkoutDto workout , string workoutId)
        {
            var workoutToUpdate = await _context.WorkOuts.FirstOrDefaultAsync(w=> w.Id == workoutId);
            if(workoutToUpdate == null){
                return new ResultDto<string>()
                {
                    Message = "Workout not found",
                    Success = false
                };
            }
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
                return new ResultDto<string>()
                {
                    Message = ex.Message,
                    Success = false
                };
            }
            return new ResultDto<string>()
            {
                Message = "Workout updated successfully",
                Success = true
            };
        }
        public async Task<ResultDto<string>> AssignExerciseToWorkout(List<string> guids , string workoutId)
        {
            _user = await ValidateUser();
            if(_user == null)        
            {
                return new ResultDto<string>()
                {
                    Message = "User not found",
                    Success = false
                };
            }
            if(workoutId == null){
                return new ResultDto<string>()
                {
                    Message = "Workout not found",
                    Success = false
                };
            }
            var Workout1 = await _context.WorkOuts.FirstOrDefaultAsync(w=> w.Id == workoutId);
            if(Workout1 == null){
                return new ResultDto<string>(){
                    Message = "Workout not found",
                    Success = false
                };
            }
            List<WorkoutExercise> elements = new List<WorkoutExercise>();
            foreach(var guid in guids){
                elements.Add(new WorkoutExercise{
                    WorkoutId = workoutId.ToString(),
                    ExerciseId = guid
                });
            }
            try{
                await _context.SaveChangesAsync();
            }
            catch(Exception ex){
                return new ResultDto<string>(){
                    Message = ex.Message,
                    Success = false
                };
            }
            return new ResultDto<string>(){
                Message = "The Excersises Succesfully added",
                Success = true
            };
        }
        public async Task<ResultDto<IEnumerable<GetWorkoutDTO>>> GetAllWorkouts()
        {
            var workouts = await _context.WorkOuts
                .Join(_context.Users,
                    w => w.UserId,
                    u => u.Id,
                    (w, u) => new { w, u.UserName })
                .Join(_context.WorkoutExercises,
                    wu => wu.w.Id,
                    we => we.WorkoutId,
                    (wu, we) => new { wu.w, wu.UserName, we.ExerciseId })
                .GroupBy(g => new { g.w.Id, g.UserName, g.w.Title, g.w.CreationDate, g.w.Notes , g.w.EndDate , g.w.Finished })
                .Select(group => new GetWorkoutDTO
                {
                    Id = group.Key.Id,
                    name = group.Key.UserName,
                    Title = group.Key.Title,
                    CreationDate = group.Key.CreationDate,
                    EndDate = group.Key.EndDate,
                    Finished = group.Key.Finished,
                    Notes = group.Key.Notes,
                    ExerciseIds = group.Select(g => g.ExerciseId).ToList()
                })
                .OrderByDescending(g => g.CreationDate)
                .ToListAsync();


            if(workouts == null)
            {
                throw new Exception("No workouts found");
            }

            return new ResultDto<IEnumerable<GetWorkoutDTO>>()
            {
                Message = "Workouts found",
                Success = true,
                Data = workouts
            };
            
        }
        public async Task<ResultDto<string>> UpdateStatus(string workoutId , int status)
        {
            var workout = _context.WorkOuts.FirstOrDefault(w=> w.Id == workoutId);
            if(workout == null){
                return new ResultDto<string>()
                {
                    Message = "Workout not found",
                    Success = false
                };
            }
            if(status == 2) workout.Status = Status.Completed;
            else if(status == 3) workout.Status = Status.TimeOut;
            else workout.Status = Status.Pending;
            try{
                _context.WorkOuts.Update(workout);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex){
                return new ResultDto<string>()
                {
                    Message = ex.Message,
                    Success = false
                };
            }
            return new ResultDto<string>()
            {
                Message = "Status updated successfully",
                Success = true
            };
        }
    }
}
