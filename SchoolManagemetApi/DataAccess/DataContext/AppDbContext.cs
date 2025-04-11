using Microsoft.EntityFrameworkCore;
using SchoolManagemetApi.Domain.Model;

namespace SchoolManagemetApi.DataAccess.DataContext
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Faculty>()
                .HasMany(f => f.Departments)
                .WithOne()
                .HasForeignKey(d => d.FacultyId);

            modelBuilder.Entity<Department>()
                .HasKey(d => d.Id);
        }
    }
}
