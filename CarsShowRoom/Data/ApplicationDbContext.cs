using CarShowRoom.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Cars> Cars { get; set; }
    }
}
