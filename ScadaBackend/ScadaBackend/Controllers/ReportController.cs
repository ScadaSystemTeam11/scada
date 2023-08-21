using Microsoft.AspNetCore.Mvc;
using ScadaBackend.Interfaces;

namespace ScadaBackend.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("/TimePeriodAlarmReport")]
        public async Task<IActionResult> GetAlarmsInTimePeriod([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            try
            {
                var alarms = await  this._reportService.GetAlarmsInTimePeriod(start, end);
                return Ok(alarms);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while fetching alarms from certain time period.");
            }

        }

        [HttpGet("/PriorityReport")]
        public async Task<IActionResult> GetAlarmsByPriority([FromQuery] int priority)
        {
            try
            {
                var alarms = await this._reportService.GetAlarmsByPriority(priority);

                return Ok(alarms);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while fetching alarms by priority.");
            }
        }

        [HttpGet("/TimePeriodTagsReport")]
        public async Task<IActionResult> GetTagsByInTimePeriod([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            try
            {
                var tags = await this._reportService.GetTagsInTimePeriod(start, end);
                return Ok(tags);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while fetching Tag Changes from certain time period.");
            }
        }

        [HttpGet("/LastAIReport")]
        public async Task<IActionResult> GetLastValuesOfAITags()
        {
            try
            {
                var tags = await this._reportService.GetLastValuesOfAITags();
                return Ok(tags);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while fetching last values of Analog Input Tags.");
            }
        }

        [HttpGet("LastDIReport")]
        public async Task<IActionResult> GetLastValuesOfDITags()
        {
            try
            {
                var tags = await this._reportService.GetLastValuesOfDITags();
                return Ok(tags);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while fetching last values of Digital Input Tags.");
            }
        }

        [HttpGet("TagsByIDReport")]
        public async Task<IActionResult> GetAllTagsById([FromQuery] string id)
        {
            try
            {
                var tags = await this._reportService.GetTagValuesById(id);
                return Ok(tags);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while fetching all Tag Changes for a certain Tag.");
            }
        }
    }
}
