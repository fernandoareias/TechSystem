using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSystem.Models
{
   [Table("[Employee]")]
   public class Employee
   {

      [Key]
      public int Id { get; set; }

      [Required(ErrorMessage = "Esse campo é obrigatório")]
      [MaxLength(80, ErrorMessage = "Esse campo deve contre entre 2 a 80 caractéres")]
      [MinLength(3, ErrorMessage = "Esse campo deve contre entre 2 a 80 caractéres")]
      public string Name { get; set; }

      [Required(ErrorMessage = "Esse campo é obrigatório")]
      [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
      public decimal Wage { get; set; }

      [Required(ErrorMessage = "Esse campo é obrigatório")]
      [MaxLength(2, ErrorMessage = "Esse campo deve contre entre 0 a 2 caractéres")]
      [MinLength(0, ErrorMessage = "Esse campo deve contre entre 0 a 2 caractéres")]
      public string Gender { get; set; }

      [Required(ErrorMessage = "Esse campo é obrigatório")]
      public string Role { get; set; }

      public List<Dependent> Dependents { get; set; }

      [Required(ErrorMessage = "Esse campo é obrigatório")]
      public int DepartmentId { get; set; }

   }
}