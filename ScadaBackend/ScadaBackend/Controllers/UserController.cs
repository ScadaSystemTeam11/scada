using Microsoft.AspNetCore.Mvc;
using ScadaBackend.DTOs;
using ScadaBackend.Interfaces;
using ScadaBackend.Models;

namespace ScadaBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            return Ok(userDto);
        }
  
    }
}