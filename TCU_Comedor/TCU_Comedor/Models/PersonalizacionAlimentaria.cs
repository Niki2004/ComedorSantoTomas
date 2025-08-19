using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class PersonalizacionAlimentaria
    {
        [Key]
        public int Id_PersonalizacionAlimentaria { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [MaxLength(100)]
        [Display(Name = "Preferencia de Comida")]
        public string Preferencias { get; set; }

    }
}