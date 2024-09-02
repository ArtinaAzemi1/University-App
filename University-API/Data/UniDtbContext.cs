using Microsoft.EntityFrameworkCore;
using University_API.Models;

namespace University_API.Data
{
    public class UniDtbContext
    {
        public class UniDtbContext : DbContext
        {
            public UniDtbContext(DbContextOptions<UniDtbContext> options) : base(options)
            {
            }

            public DbSet<Student> Students { get; set; }
            public DbSet<Professor> Professors { get; set; }
            public DbSet<Department> Department { get; set; }
            public DbSet<Course> Course { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Student>()
                    .HasOne(s => s.Department)
                    .WithMany(d => d.Students)
                    .HasForeignKey(s => s.DepartmentId);

                base.OnModelCreating(modelBuilder);
            }
        }
    }
}
