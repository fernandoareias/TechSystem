

using System;
using Dapper.Contrib.Extensions;

namespace BOBTechSystem.Models
{
   [Table("Dependent")]
   public class Dependents
   {
      public Guid Id { get; set; }
      public string Name { get; set; }
      public Guid EmployeeId { get; set; }
   }
}