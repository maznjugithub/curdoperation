using Demo5.Dataacess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo5.Dataacess
{
    public class AppDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teacher { get; set; }
		public DbSet<Book> Book { get; set; }
		public DbSet<Class> Class{ get; set; }
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
