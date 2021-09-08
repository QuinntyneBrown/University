using University.Api.Models;
using University.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace University.Api.Data
{
    public class UniversityDbContext: DbContext, IUniversityDbContext
    {
        public DbSet<Cellphone> Cellphones { get; private set; }
        public DbSet<Book> Books { get; private set; }
        public DbSet<Student> Students { get; private set; }
        public UniversityDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UniversityDbContext).Assembly);
        }
        
    }
}
