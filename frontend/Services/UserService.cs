namespace frontend.Services;

/// <summary>
/// Almacén en memoria para la demo de gestión de usuarios.
/// Registrado como Singleton: los datos viven mientras el proceso esté arriba
/// y se pierden al reiniciar. Para producción, reemplazar por un repositorio
/// respaldado en base de datos (EF Core, Dapper, etc.) manteniendo la misma
/// interfaz pública para no tocar la página.
/// </summary>
public class UserService
{
    private readonly List<User> _users = new();
    private int _nextId = 1;

    public UserService()
    {
        Seed();
    }

    public IReadOnlyList<User> GetAll() => _users;

    public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

    public User Add(User user)
    {
        user.Id = _nextId++;
        user.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
        _users.Add(user);
        return user;
    }

    public bool Update(User updated)
    {
        var existing = GetById(updated.Id);
        if (existing is null) return false;

        existing.Name = updated.Name;
        existing.Email = updated.Email;
        existing.Role = updated.Role;
        existing.Active = updated.Active;
        return true;
    }

    public bool Delete(int id) => _users.RemoveAll(u => u.Id == id) > 0;

    private void Seed()
    {
        Add(new User { Name = "Esteban Carfilaf", Email = "esteban@example.com", Role = "Admin", Active = true });
        Add(new User { Name = "Lucía Ferreyra", Email = "lucia.ferreyra@example.com", Role = "Editor", Active = true });
        Add(new User { Name = "Martín Gómez", Email = "martin.gomez@example.com", Role = "Viewer", Active = false });
        Add(new User { Name = "Sofía Ramírez", Email = "sofia.ramirez@example.com", Role = "Editor", Active = true });
    }
}
