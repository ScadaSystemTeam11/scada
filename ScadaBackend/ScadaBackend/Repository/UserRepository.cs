using Microsoft.IdentityModel.Tokens;
using ScadaBackend.Interfaces;
using ScadaBackend.Models;
using ScadaBackend.Data;
using AppContext = ScadaBackend.Data.AppContext;

namespace ScadaBackend.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppContext _context;
    public UserRepository(AppContext context) {
        _context = context;
    }
    
    public ICollection<User> GetUsers()
    {
        return _context.Users.ToList();
    }

    public User? FindUser(string username, string password)
    {
        return _context.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public bool DoesUserExist(string username)
    {
        return _context.Users.Any(u => u.Username == username);
    }
}