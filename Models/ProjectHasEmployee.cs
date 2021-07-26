using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechSystem.Models;

namespace TechSystem.Models
{
   [Table("ProjectHasEmployee")]

   public class ProjectHasEmployee
   {
      [Key]
      public int Id { get; set; }

      [Required(ErrorMessage = "Esse campo é obrigatório")]
      public List<Employee> EmployeeId { get; set; }

      [Required(ErrorMessage = "Esse campo é obrigatório")]
      public int DepartmentId { get; set; }

   }
}