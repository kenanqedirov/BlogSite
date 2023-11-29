using Microsoft.EntityFrameworkCore;

namespace BlogApi.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=localhost\SQL;database=CoreBlogApiDb;User Id=sa;Password=kenan4258; integrated security = true; Encrypt=false");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
