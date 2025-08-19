using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class CategoriaAlimento
    {
        [Key]
        public int Id_CategoriaAlimento { get; set; }

        [ForeignKey("Nutricion")]
        public int Id_Nutricion { get; set; }
        public Nutricion Nutricion { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nombre de Categoría")]
        public string NombreCategoria { get; set; }

        [MaxLength(100)]
        public string Descripcion { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }

    }
}