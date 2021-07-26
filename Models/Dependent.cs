using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechSystem.Models;

namespace TechSystem.Models
{
   [Table("Dependent")]
   public class Dependents
   {
      [Key]
      public int Id { get; set; }

      [Required(ErrorMessage = "Esse campo é obrigatório")]
      [MaxLength(80, ErrorMessage = "Esse campo deve contre entre 2 a 80 caractéres")]
      [MinLength(3, ErrorMessage = "Esse campo deve contre entre 2 a 80 caractéres")]
      public string Name { get; set; }

      [Required(ErrorMessage = "Esse campo é obrigatório")]
      public int EmployeeId { get; set; }
   }
}