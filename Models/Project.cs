using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSystem.Models
{
   [Table("Projects")]

   public class Project
   {
      [Key]
      public int Id { get; set; }
      [Required(ErrorMessage = "Esse campo é obrigatório")]
      [MaxLength(80, ErrorMessage = "Esse campo deve conter de 2 a 80 caractéres")]
      public string Name { get; set; }
      public DateTime InitialDate { get; set; }
      /*
            [Write(false)]
            public List<Project> Projects { get; set; }
            */
   }
}