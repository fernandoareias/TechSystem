using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace BOBTechSystem.Models
{
   [Table("[Employee]")]
   public class Employee
   {

      public Guid Id { get; set; }
      public string Name { get; set; }
      public float Wage { get; set; }
      public string Gender { get; set; }
      public Guid SupervisorId { get; set; }
      public Guid Department { get; set; }

      [Write(false)]
      public List<Employee> Employees { get; set; }
   }
}