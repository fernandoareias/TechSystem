using System;
using Dapper.Contrib.Extensions;

namespace BOBTechSystem.Models
{
   [Table("ProjectMinute")]
   public class ProjectMinute
   {
      public Guid Id { get; set; }
      public string Minutes { get; set; }
      public Guid ProjectId { get; set; }
   }
}