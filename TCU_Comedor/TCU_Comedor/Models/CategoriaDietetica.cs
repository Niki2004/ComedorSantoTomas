using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class CategoriaDietetica
    {
        [Key]
        public int Id_CategoriaDietetica { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [MaxLength(100)]
        [Display(Name = "Tipo de comidas")]
        public string Tipo { get; set; }

        [MaxLength(100)]
        [Display(Name = "Detalles de la comida")]
        public string Detalles { get; set; }

    }
}