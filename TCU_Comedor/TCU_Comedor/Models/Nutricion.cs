using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class Nutricion
    {
        [Key]
        public int Id_Nutricion { get; set; } 

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [MaxLength(100)]
        public string Detalle { get; set; }
        
    }
}