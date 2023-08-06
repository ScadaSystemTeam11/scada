using Microsoft.AspNetCore.Mvc;
using ScadaBackend.DTOs;
using ScadaBackend.Interfaces;
using ScadaBackend.Models;
using ScadaBackend.Services;

namespace ScadaBackend.Controllers
{
    [Route("api/[controller]")] 
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITagService _tagService;

        public UserController(IUserRepository userRepository, ITagService tagService)
        {
            _userRepository = userRepository;
            _tagService = tagService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginUserDTO dto)
        {
            User? user = _userRepository.FindUser(dto.Username, dto.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            UserDTO userDto = new UserDTO(user);

            _tagService.StartSimulationAsync();
            return Ok(userDto);
        }

  
    }
}