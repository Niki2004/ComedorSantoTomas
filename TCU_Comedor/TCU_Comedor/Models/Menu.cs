using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class Menu
    {
        [Key]
        public int Id_Menu { get; set; }

        [ForeignKey("CategoriaMenu")]
        public int Id_CategoriaMenu { get; set; } //Desayuno, merienda o almuerzo 
        public CategoriaMenu CategoriaMenu { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nombre de Comida")]
        public string NombreComida { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Registro")]
        public DateTime FechaMenu { get; set; }

    }
}