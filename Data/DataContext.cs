
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
      public DbSet<Dependent> Dependents { get; set; }
      public DbSet<Department> Department { get; set; }
      public DbSet<DepartmentHasProject> DepartMentHasProjects { get; set; }
      public DbSet<Project> Projects { get; set; }
      public DbSet<ProjectHasEmployee> ProjectHasEmployees { get; set; }
      public DbSet<ProjectMinute> ProjectMinutes { get; set; }
      public DbSet<ProjectStep> ProjectSteps { get; set; }



   }
}