using UserApi.Models;

namespace UserApi.Services;

public class UserRepository
{
    private readonly List<User> _users = new();
    private int _idCounter = 1;

    public IEnumerable<User> GetAll() => _users;

    public User? Get(int id) => _users.FirstOrDefault(u => u.Id == id);

    public User Add(User user)
    {
        user.Id = _idCounter++;
        _users.Add(user);
        return user;
    }

    public bool Update(int id, User updatedUser)
    {
        var user = Get(id);
        if (user is null) return false;

        user.FullName = updatedUser.FullName;
        user.Email = updatedUser.Email;
        return true;
    }

    public bool Delete(int id)
    {
        var user = Get(id);
        if (user is null) return false;
        _users.Remove(user);
        return true;
    }
}
