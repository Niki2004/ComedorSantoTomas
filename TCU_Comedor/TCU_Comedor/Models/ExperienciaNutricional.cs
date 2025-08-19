using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class ExperienciaNutricional
    {
        [Key]
        public int Id_ExperienciaNutricional { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [MaxLength(100)]
        public string Experiencia { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Registro")]
        public DateTime FechaExperienciaNutricional { get; set; }
    }
}