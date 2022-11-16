using AkshayMore.Model;
using Microsoft.EntityFrameworkCore;

namespace AkshayMore
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "EmployeeDB");
        }
        public DbSet<Employee> Employees { get; set; } = null!;
    }
}
