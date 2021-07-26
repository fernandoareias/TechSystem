using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TechSystem.Models
{
   [Table("DepartmentHasProject")]
   public class DepartmentHasProject
   {
      [Key]
      public int Id { get; set; }
      [Required(ErrorMessage = "Esse campo é obrigatório")]
      public int DepartmentId { get; set; }

      [Required(ErrorMessage = "Esse campo é obrigatório")]
      public int ProjectId { get; set; }


   }
}