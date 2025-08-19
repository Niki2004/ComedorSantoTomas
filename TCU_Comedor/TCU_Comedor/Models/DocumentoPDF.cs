using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class DocumentoPDF
    {
        [Key]
        public int Id_DocumentoPDF { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(250)]
        public string Ruta { get; set; }

    }
}