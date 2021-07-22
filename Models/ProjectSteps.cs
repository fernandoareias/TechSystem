
using System;
using Dapper.Contrib.Extensions;

namespace BOBTechSystem.Models
{
   [Table("ProjectSteps")]

   public class ProjectSteps
   {
      public Guid Id { get; set; }
      public string Step { get; set; }
      public Guid ProjectId { get; set; }
   }
}