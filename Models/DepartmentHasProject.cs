using System;
using Dapper.Contrib.Extensions;

namespace BOBTechSystem.Models
{
   [Table("DepartmentHasProject")]
   public class DepartmentHasProject
   {
      public Guid DepartmentId { get; set; }
      public Guid ProjectId { get; set; }


   }
}