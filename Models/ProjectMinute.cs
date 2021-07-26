using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSystem.Models
{
   [Table("ProjectMinute")]
   public class ProjectMinute
   {
      [Key]
      public int Id { get; set; }

      [MaxLength(120, ErrorMessage = "Esse campo pode conter no máximo 120 caractéres")]
      public string Minutes { get; set; }

      [Required(ErrorMessage = "Esse campo é obrigatório")]
      public int ProjectId { get; set; }
   }
}