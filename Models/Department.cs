using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechSystem.Models;

namespace TechSystem.Models
{
   [Table("Department")]
   public class Department
   {
      [Key]
      public int Id { get; set; }


      [Required(ErrorMessage = "Esse campo é obrigatório")]
      [Range(1, int.MaxValue, ErrorMessage = "O budget deve ser maior que zero")]
      public decimal Budget { get; set; }

      [Required(ErrorMessage = "Este campo é obrigatório")]

      public int SupervisorId { get; set; }
      public List<Employee> Employees { get; set; }


   }
}