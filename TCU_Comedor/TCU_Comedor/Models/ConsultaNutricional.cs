using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class ConsultaNutricional
    {
        [Key]
        public int Id_ConsultaNutricional { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [MaxLength(100)]
        public string Detalles { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha del Registro")]
        public DateTime FechaConsultaNutricional { get; set; }
    }
}