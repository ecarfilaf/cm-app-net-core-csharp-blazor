using Microsoft.EntityFrameworkCore;
using apibackend.Models;

namespace apibackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UsuUsuarios> Usuarios { get; set; }
    }
}