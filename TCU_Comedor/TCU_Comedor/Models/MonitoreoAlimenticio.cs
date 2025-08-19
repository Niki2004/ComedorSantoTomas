using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class MonitoreoAlimenticio
    {
        [Key]
        public int Id_MonitoreoAlimenticio { get; set; }

        [ForeignKey("Menu")]
        public int Id_Menu { get; set; }
        public Menu Menu { get; set; }

        [MaxLength(100)]
        public string Observacion { get; set; }
    }
}