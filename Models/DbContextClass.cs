using Microsoft.EntityFrameworkCore;

namespace NewProjectOnMVCFullStack.Models
{
    public class DbContextClass:DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass>options):base(options)
        {
            
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Categories> Category { get; set; }
        public DbSet<Products> Product { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=BHUKRK527198L\\SqlServerNew;Initial Catalog=FullStackDB;User Id=sa;Password=Niranjan@20;TrustServerCertificate=true;");
        }
    }
}
