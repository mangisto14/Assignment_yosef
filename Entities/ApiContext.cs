using Microsoft.EntityFrameworkCore;
using WebApi.Entities.Models;

namespace WebApi
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TestDb");
            
        }
        public DbSet<User> Users { get; set; }
    }
}
