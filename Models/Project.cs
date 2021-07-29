using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSystem.Models
{
   [Table("Projects")]

   public class Project
   {
      public Project()
      {
         InitialDate = DateTime.Now;
      }
      [Key]
      public int Id { get; set; }

      [Required(ErrorMessage = "Esse campo é obrigatório")]
      [MaxLength(80, ErrorMessage = "Esse campo deve conter de 2 a 80 caractéres")]
      public string Name { get; set; }

      public DateTime InitialDate { get; set; }

      public List<ProjectStep> Steps { get; set; }

      public List<ProjectMinute> Minute { get; set; }

   }
}