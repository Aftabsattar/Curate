using Curate.Entities;
using Microsoft.EntityFrameworkCore;

namespace Curate.Contex
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }
        public DbSet<User> user { get; set; }
    }
}