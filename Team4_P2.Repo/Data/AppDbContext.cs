using Microsoft.EntityFrameworkCore;
using Team4_P2.Models;
using Team4_P2.Models.Models;

namespace Team4_P2.Repo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}
