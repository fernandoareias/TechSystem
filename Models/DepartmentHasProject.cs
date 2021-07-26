using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BOBTechSystem.Models
{
   [Table("DepartmentHasProject")]
   public class DepartmentHasProject
   {

      [Required(ErrorMessage = "Esse campo é obrigatório")]
      public int DepartmentId { get; set; }

      [Required(ErrorMessage = "Esse campo é obrigatório")]
      public int ProjectId { get; set; }


   }
}