using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScadaBackend.DTOs;
using ScadaBackend.Interfaces;
using ScadaBackend.Models;
using ScadaBackend.Repository;
using ScadaBackend.Services;
using System.Security.Claims;

namespace ScadaBackend.Controllers
{
    [Route("api/[controller]")]
    public class AlarmController : Controller
    {
        private readonly IAlarmService _alarmService;

        public AlarmController(IAlarmService alarmService)
        {
            _alarmService = alarmService;
        }

        [HttpPost("AddAlarm")]
        public async Task<IActionResult> AddAlarm([FromBody] AlarmDTO alarm)
        {
            try
            {
                var createdAlarm = await this._alarmService.AddAlarm(alarm);
                return Ok(createdAlarm);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while creating alarm");

            }
        }

        [HttpDelete("RemoveAlarm")]
        public async Task<IActionResult> RemoveAlarm([FromQuery] Guid id)
        {
            try
            {
                var removed = await this._alarmService.RemoveAlarm(id);
                return Ok(removed);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while removing alarm");

            }
        }
    }
}
