using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSystem.Models
{
   [Table("ProjectSteps")]

   public class ProjectStep
   {
      [Key]
      public int Id { get; set; }

      [MaxLength(80, ErrorMessage = "Esse campo deve conter no máximo 80 caractéres")]
      public string Step { get; set; }

      [Required(ErrorMessage = "Esse campo é obrigatório")]
      public int ProjectId { get; set; }
   }
}