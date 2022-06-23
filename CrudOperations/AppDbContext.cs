using CrudOperations.Models;
using Microsoft.EntityFrameworkCore;
namespace CrudOperations
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Filiere> Filieres { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
