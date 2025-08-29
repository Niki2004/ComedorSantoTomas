using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class AjustesViewModel
    {
        public List<PersonalizacionAlimentaria> Informes { get; set; }
        public List<Nutricion> Nutriciones { get; set; }
    }
}