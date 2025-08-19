using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class CategoriaProveedor
    {
        [Key]
        public int Id_Alergia { get; set; }

        public string Descripcion { get; set;} //Tipo de alimento: Pollo, papas...
    }
}