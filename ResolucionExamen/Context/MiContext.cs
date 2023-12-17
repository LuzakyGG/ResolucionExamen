using Microsoft.EntityFrameworkCore;
using ResolucionExamen.Models;

namespace ResolucionExamen.Context
{
    public class MiContext:DbContext
    {
        public MiContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<usuario>usuarios { get; set; }
        public DbSet<refresco>refrescos { get; set; }
    }
}
