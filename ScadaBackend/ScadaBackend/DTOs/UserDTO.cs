using ScadaBackend.Models;

namespace ScadaBackend.DTOs;

public class UserDTO
{
    public string Username { get; set; }
    public int Id { get; set; }
    public string Role { get; set; }

    public UserDTO(string username, string role, int id)
    {
        Username = username;
        Role = role;
        Id = id;
    }

    public UserDTO(User user)
    {
        Username = user.Username;
        Id = user.Id;
        Role = user.Role;

    }
}