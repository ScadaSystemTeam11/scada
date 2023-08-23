using System.Buffers.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ScadaBackend.DTOs;
using ScadaBackend.Interfaces;
using ScadaBackend.Models;
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

            if (dto.CurrentValue != 1 && dto.CurrentValue != 0)
                return BadRequest("Invalid tag value");
            if (dto.ScanTime < 0) return BadRequest("Invalid scan time");
            var tag = await _tagService.CreateDigitalInputTag(dto);
            return Ok(tag);
        }

        [HttpPost("CreateDigitalOutputTag")]
        public async Task<IActionResult> CreateDigitalOutputTag([FromBody] DigitalOutputDTO dto)
        {
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
            var tag = await _tagService.CreateAnalogInputTag(dto);
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

        [HttpDelete("DeleteDigitalInputTag")]
        public async Task<IActionResult> DeleteDigitalInputTag([FromQuery] Guid id)
        {
            Console.WriteLine("Ulazimo ovde");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var deleted = _tagService.DeleteDigitalInputTag(id);
            Console.WriteLine("This tag has been deleted");
            return Ok("Deleted Tag succesfully");
        }

        [HttpDelete("DeleteAnalogInputTag")]
        public async Task<IActionResult> DeleteAnalogInputTag([FromQuery] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var deleted = _tagService.DeleteAnalogInputTag(id);
            return Ok("Deleted Tag succesfully");
        }

        [HttpDelete("DeleteDigitalOutputTag")]
        public async Task<IActionResult> DeleteDigitalOutputTag([FromQuery] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var deleted = _tagService.DeleteDigitalOutputTag(id);
            return Ok("Deleted Tag succesfully");
        }

        [HttpDelete("DeleteAnalogOutputTag")]
        public async Task<IActionResult> DeleteAnalogOutputTag([FromQuery] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var deleted = _tagService.DeleteAnalogOutputTag(id);
            return Ok("Deleted Tag succesfully");
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

        [HttpGet("AnalogOutputs")]
        public async Task<IActionResult> GetAnalogOutputs()
        {
            try
            {

                var analogOutputs = await _tagService.GetAnalogOutputs();
                return Ok(analogOutputs);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occured while fetching analog outputs");
            }
        }
        
        [HttpGet("DigitalOutputs")]
        public async Task<IActionResult> GetDigitalOutputs()
        {
            try
            {

                var di = await _tagService.GetDigitalOutputs();
                return Ok(di);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occured while fetching digital outputs");
            }
        }
        

        [HttpPut("InputScanOnOff")]
        public async Task<IActionResult> SetTagScanOnOff(
            [FromBody] InputTagDTO inputTagDto)
        {

            var setScan = await _tagService.SetScan(inputTagDto.Id, inputTagDto.Type, inputTagDto.Scan);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(setScan);
        }

        [HttpPut("UpdateOutputTagValue")]
        public async Task<IActionResult> UpdateOutputTagValue(
            [FromBody] OutputTagValueDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (dto.Type.ToLower() == "digital")
            {
                if (dto.Value < 0 || dto.Value > 1)
                    return BadRequest("Value must be 0 or 1");
                var di = await _tagService.GetDigitalOutputById(dto.Id);
                if (di == null)
                    return BadRequest("Tag with that Id does not exist");
                di.CurrentValue = dto.Value;
                bool updated = await _tagService.UpdateDigitalOutput(di.ID, dto.Value);

                return Ok(updated);
            }

            if (dto.Type.ToLower() == "analog")
            {
                var analogOutput = await _tagService.GetAnalogOutputById(dto.Id);
                if (analogOutput == null)
                 return BadRequest("Tag with that Id does not exist");
                if (dto.Value > analogOutput.HighLimit)
                {
                    return BadRequest("Value of tag is higher than limit");
                }
                if (dto.Value < analogOutput.LowLimit)
                {
                    return BadRequest("Value of tag is lower than limit");
                }
                analogOutput.CurrentValue = dto.Value;
                bool updated = await _tagService.UpdateAnalogOutput(analogOutput.ID, dto.Value);
                return Ok(updated);
            }

            return BadRequest("Type of tag must be 'digital' or 'analog'");

        }


        [HttpGet("ActiveInputs")]
        public async Task<IActionResult> GetActiveIputs()
        {
            try
            {
                var activeInputs = await _tagService.GetActiveInputTags();
                return Ok(activeInputs);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while fetching active inputs.");
            }
        }


        [HttpGet("AllTags")]
        public async Task<IActionResult> GetAllTags()
        {
            try
            {
                var allTags = await _tagService.GetAllTags();

                return Ok(allTags);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred while fetching tags.");
            }
        }

    }

}
