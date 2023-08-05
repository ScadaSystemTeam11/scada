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
}