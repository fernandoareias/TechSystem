using System;
using Dapper.Contrib.Extensions;

namespace BOBTechSystem.Models
{
   [Table("ProjectHasEmployee")]

   public class ProjectHasEmployee
   {
      public Guid Id { get; set; }
      public Guid EmployeeId { get; set; }
      public Guid DepartmentId { get; set; }

   }
}