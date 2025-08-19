using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class CategoriaMenu
    {
        [Key]
        public int Id_CategoriaMenu { get; set; }

        [MaxLength(100)]
        public string Descripcion { get; set; }
    }
}