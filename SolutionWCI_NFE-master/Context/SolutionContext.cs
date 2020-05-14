using Microsoft.EntityFrameworkCore;
using Model.Corretoras;

namespace Context
{
    public class SolutionContext : DbContext
    {
        public SolutionContext(DbContextOptions<SolutionContext> options)
            : base(options)
        { }

        // Corretora
        public DbSet<Corretora> Corretoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
