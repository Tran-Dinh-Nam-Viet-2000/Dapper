using Microsoft.EntityFrameworkCore;

namespace Test_Dapper.Entites
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
