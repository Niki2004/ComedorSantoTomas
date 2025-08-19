using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class Proveedor
    {
        [Key]
        public int Id_Proveedor { get; set; }

        [ForeignKey("CategoriaProveedor")]
        public int Id_CategoriaProveedor { get; set; }
        public CategoriaProveedor CategoriaProveedor { get; set; }

        public string Costos { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nombre del Proveedor")]
        public string NombreProveedor { get; set; }

        [MaxLength(100)]
        [Display(Name = "Número del Proveedor")]
        public string NumeroProveedor { get; set; }

        [Display(Name = "Correo del Proveedor")]
        public string CorreoProveedor { get; set; }

    }
}