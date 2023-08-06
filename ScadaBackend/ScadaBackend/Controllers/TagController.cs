using Microsoft.AspNetCore.Mvc;
using ScadaBackend.DTOs;
using ScadaBackend.Interfaces;
using ScadaBackend.Repository;

namespace ScadaBackend.Controllers
{

    [Route("api/[controller]")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        { 
            _tagService = tagService;
        }
        
        [HttpGet("DigitalInputs")]
        public async Task<IActionResult> GetDigitalInputs()
        {
            try
            {
                var digitalInputs = await _tagService.GetDigitalInputTags();
                return Ok(digitalInputs);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while fetching digital inputs.");
            }
        }
        
        [HttpGet("AnalogInputs")]
        public async Task<IActionResult> GetAnalogInputs()
        {
            try
            {
                var analogInputs = await _tagService.GetAnalogInputTags();
                return Ok(analogInputs);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while fetching analog inputs.");
            }
        }
        
        [HttpPut("inputScanOnOff")]
        public async Task<IActionResult> SetTagScanOnOff(
            [FromBody]InputTagDTO inputTagDto)
        {
            
            var setScan =await _tagService.SetScan(inputTagDto.Id,  inputTagDto.Type, inputTagDto.Scan);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(setScan);
        }
    }
}