using System.Buffers.Text;
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
        
        [HttpPost("CreateDigitalInputTag")]
        public async Task<IActionResult> CreateDigitalInputTag([FromBody] DigitalInputDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (dto.CurrentValue <= 1 && dto.CurrentValue >= 0) 
                return BadRequest("Invalid tag value");
            if (dto.ScanTime < 0) return BadRequest("Invalid scan time");
            var tag =await _tagService.CreateDigitalInputTag(dto);
            return Ok(tag);
        }

        [HttpPost("CreateDigitalOutputTag")]
        public async Task<IActionResult> CreateDigitalOutputTag([FromBody] DigitalOutputDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (dto.InitialValue < 0) return BadRequest("Invalid value of tag");
            var tag = await _tagService.CreateDigitalOutputTag(dto);
            return Ok(tag);
        }
        
        [HttpPost("CreateAnalogInputTag")]
        public async Task<IActionResult> CreateAnalogInputTag([FromBody] AnalogInputDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (dto.CurrentValue < 0) return BadRequest("Invalid tag value");
            if (dto.ScanTime < 0) return BadRequest("Invalid scan time");
            if (dto.HighLimit <= dto.LowLimit) return BadRequest("Invalid high limit");
            if (dto.LowLimit < 0) return BadRequest("Invalid low limit");
            var tag =await _tagService.CreateAnalogInputTag(dto);
            return Ok(tag);
        }
        
        [HttpPost("CreateAnalogOutputTag")]
        public async Task<IActionResult> CreateAnalogOutputTag([FromBody] AnalogOutputDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (dto.InitialValue < 0) return BadRequest("Invalid value of tag");
            if (dto.HighLimit <= dto.LowLimit) return BadRequest("Invalid high limit");
            if (dto.LowLimit < 0) return BadRequest("Invalid low limit");
            var tag = await _tagService.CreateAnalogOutputTag(dto);
            return Ok(tag);
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
        
        [HttpPut("InputScanOnOff")]
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