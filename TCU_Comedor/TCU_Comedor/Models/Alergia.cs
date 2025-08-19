using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class Alergia
    {
        [Key]
        public int Id_Alergia { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; } 
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "¿Tiene alergias?")]
        public bool Alergias { get; set; }   // true = sí, false = no

        [MaxLength(100)]
        [Display(Name = "¿Cuáles alergias?")]
        public string DetalleAlergias { get; set; } // se llena solo si Alergias = true

        [Display(Name = "¿Tiene enfermedades?")]
        public bool Enfermedades { get; set; } // true = sí, false = no

        [MaxLength(100)]
        [Display(Name = "¿Cuáles enfermedades?")]
        public string DetalleEnfermedades { get; set; }   // se llena solo si Enfermedades = true

    }
}