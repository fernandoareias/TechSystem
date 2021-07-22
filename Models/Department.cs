
using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace BOBTechSystem.Models
{
   [Table("Department")]
   public class Department
   {
      public Guid Id { get; set; }
      public float Budget { get; set; }
      public Guid SupervisorId { get; set; }


   }
}