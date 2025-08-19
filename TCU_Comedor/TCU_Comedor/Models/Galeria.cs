using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class Galeria
    {
        [Key]
        public int Id_Galeria { get; set; }

        [ForeignKey("AgendaAlimenticia")]
        public int Id_AgendaAlimenticia { get; set; } 
        public AgendaAlimenticia AgendaAlimenticia { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Registro")]
        public DateTime FechaMenu { get; set; }

    }
}