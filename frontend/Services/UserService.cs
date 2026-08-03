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

        existing.rut = updated.rut;
        existing.dv = updated.dv;
        existing.nombres = updated.nombres;
        existing.apaterno = updated.apaterno;
        existing.amaterno = updated.amaterno;
        existing.usuario = updated.usuario;
        existing.clave = updated.clave;
        existing.codestado = updated.codestado;
        existing.codtipousuario = updated.codtipousuario;
        existing.fecvigencia = updated.fecvigencia;
        existing.email = updated.email;
        existing.avatar = updated.avatar;
        existing.user = updated.user;
        existing.fun = updated.fun;
        existing.Role = updated.Role;
        existing.Active = updated.Active;
        return true;
    }

    public bool Delete(int id) => _users.RemoveAll(u => u.Id == id) > 0;

    private void Seed()
    {
        Add(new User { rut = "12345678", dv = "9", nombres = "Esteban", apaterno = "Carfilaf", amaterno = "Nuñez", email = "esteban@example.com", Role = "Admin", Active = true });
        Add(new User { rut = "87654321", dv = "0", nombres = "Lucía", apaterno = "Ferreyra", amaterno = "López", email = "lucia.ferreyra@example.com", Role = "Editor", Active = true });
        Add(new User { rut = "11223344", dv = "5", nombres = "Martín", apaterno = "Gómez", amaterno = "Rodríguez", email = "martin.gomez@example.com", Role = "Viewer", Active = false });
        Add(new User { rut = "55667788", dv = "1", nombres = "Sofía", apaterno = "Ramírez", amaterno = "Sánchez", email = "sofia.ramirez@example.com", Role = "Editor", Active = true });
    }
}
