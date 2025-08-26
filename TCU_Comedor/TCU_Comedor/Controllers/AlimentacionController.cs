using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCU_Comedor.Controllers
{
    public class AlimentacionController : Controller
    {
        // GET: Alimentacion
        [Authorize(Roles = "Usuario")]
        public ActionResult Index()
        {
            return View();
        }

        // Es para el informe personal 
        [Authorize(Roles = "Usuario")]
        public ActionResult IndexInforme()
        {
            return View();
        }
    }
}