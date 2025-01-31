using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workout.DTOs;
using Workout.Repositories.Base;

namespace Workout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcersiseServices : ControllerBase
    {
        public IUnitOfWork _unit { get; set; }
        public ExcersiseServices(IUnitOfWork unit)
        {
            _unit = unit;
        }
        [HttpGet("GetAllExcersises")]
        public async Task<IActionResult> getallResults(){
            return Ok(await _unit._excersise.GetAllExercises());
        }
        [HttpPost("Create")]
        public async Task<IActionResult> create(ExerciseDTO exercise){
            return Ok(await _unit._excersise.CreateExercise(exercise));
        }
        [HttpPut("Update")]
        public async Task<IActionResult> update(Guid id, ExerciseDTO exercise){
            return Ok(await _unit._excersise.UpdateExercise(id , exercise));
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> delete(Guid id){
            return Ok(await _unit._excersise.DeleteExercise(id));
        }
    }
}
