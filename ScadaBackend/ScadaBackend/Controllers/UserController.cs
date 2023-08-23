using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ScadaBackend.DTOs;
using ScadaBackend.Hub;
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
        
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterUserDTO dto)
        {
            
            if (_userRepository.DoesUserExist(dto.Username))
            {
                return Conflict("User with this username already exists.");
            }
            User newUser = new User
            {
                Username = dto.Username,
                Password = dto.Password,
                Role = "STANDARD"
            };

            _userRepository.AddUser(newUser);
            UserDTO userDto = new UserDTO(newUser);
            return Ok(userDto);
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

            var tagChangeHubContext = HttpContext.RequestServices.GetRequiredService<IHubContext<TagChangeHub>>();
            var alarmAlertedHubContext = HttpContext.RequestServices.GetRequiredService<IHubContext<AlarmAlertedHub>>();
            _tagService.StartSimulationAsync(tagChangeHubContext, alarmAlertedHubContext);
            return Ok(userDto);
        }

  
    }
}