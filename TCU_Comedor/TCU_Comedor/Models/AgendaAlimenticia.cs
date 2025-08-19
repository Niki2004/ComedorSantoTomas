using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class AgendaAlimenticia
    {
        [Key]
        public int Id_AgendaAlimenticia { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nombre de Comida")]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Registro")]
        public DateTime FechaAgendaAlimenticia { get; set; }
    }
}