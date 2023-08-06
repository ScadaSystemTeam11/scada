using ScadaBackend.Models;

namespace ScadaBackend.DTOs;

public class LoginUserDTO
{
    public string Username { get; set; }
    public string Password { get; set; }

    public LoginUserDTO() { }

    public LoginUserDTO(string username, string password)
    {
        this.Username = username;
        this.Password = password;
    }


}