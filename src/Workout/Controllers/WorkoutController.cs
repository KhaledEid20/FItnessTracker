using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workout.DTOs;
using Workout.Repositories.Base;

namespace Workout.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : ControllerBase
    {
        private IUnitOfWork _unit;
        public WorkoutController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        
        [HttpPost("create")]
        public async Task<ActionResult> CreateWorkout([FromBody] CreateWorkoutDto workout)
        {
            try{
                var Workout = await _unit._workout.CreateWorkout(workout);
                return Ok(Workout);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }   
        
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete([FromQuery] Guid workout)
        {
            try{
                var Workout = await _unit._workout.DeleteWorkout(workout);
                return Ok(Workout);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] WorkoutDto workout ,[FromQuery]Guid workoutId)
        {
            try{
                var Workout = await _unit._workout.UpdateWorkout(workout , workoutId);
                return Ok(Workout);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("AssignExcersises")]
        public async Task<IActionResult> AssignExcersises([FromQuery]Guid workout,[FromBody]List<string> guids){
            try{
                return Ok(await _unit._workout.AssignExerciseToWorkout(guids , workout));
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("GetAllWorkouts")]
        public async Task<IActionResult> GetWorkouts(){
            try{
                return Ok(await _unit._workout.GetAllWorkouts());
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
    }
}