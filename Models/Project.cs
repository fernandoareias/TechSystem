using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace BOBTechSystem.Models
{
   [Table("Projects")]

   public class Project
   {
      public Guid Id { get; set; }
      public string Name { get; set; }
      public DateTime InitialDate { get; set; }

      [Write(false)]
      public List<Project> Projects { get; set; }
   }
}