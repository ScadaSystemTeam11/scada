using ScadaBackend.Models;

namespace ScadaBackend.Interfaces;

public interface IUserRepository
{
    ICollection<User> GetUsers();
    User? FindUser(string username, string password);
    void  AddUser(User user);
    Boolean DoesUserExist(string username);
}