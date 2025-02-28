using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reporting.Repositories.Base;

namespace Controllers.Reporting
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        public IUnitOfWork _unit { get; set; }
        public ReportController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> createReport([FromQuery]DateTime start,[FromQuery] DateTime end){
            return Ok(await _unit._report.CreateReport(start , end));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllReports(){
            return Ok(await _unit._report.GetAllSavedReports());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetbyPeriodOfTime([FromQuery]DateTime start,[FromQuery]DateTime end){
            return Ok(await _unit._report.GetByPeriodOfTime(start , end));
        }
    }
}
