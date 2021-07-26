
using Microsoft.EntityFrameworkCore;
using TechSystem.Models;

namespace TechSystem.Data
{
   public class DataContext : DbContext
   {
      public DataContext(DbContextOptions<DataContext> options) : base(options)
      {

      }

      public DbSet<Employee> Employees { get; set; }
      public DbSet<Dependents> Products { get; set; }
      public DbSet<Department> Users { get; set; }

   }
}