using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workout.DTOs;
using Workout.Repositories.Base;

namespace Workout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public IUnitOfWork _unit { get; set; }
        
        public CommentController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetComments([FromQuery]string WorkoutID)
        {
            var comments = await _unit._comments.GetAllCommentsAsync(WorkoutID);
            return Ok(comments);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetComment([FromQuery]string id)
        {
            var comment = await _unit._comments.GetCommentByIdAsync(id);
            return Ok(comment);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateComment([FromBody]CommentDto commentDTO)
        {
            var result = await _unit._comments.CreateCommentAsync(commentDTO);
            if(result.Success){
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteComment([FromQuery]string id)
        {
            var result = await _unit._comments.DeleteCommentAsync(id);
            if(result.Success){
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateComment([FromQuery]string id,[FromBody]CommentDto commentDTO)
        {
            var result = await _unit._comments.UpdateCommentAsync(id ,commentDTO);
            if(result.Success){
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
