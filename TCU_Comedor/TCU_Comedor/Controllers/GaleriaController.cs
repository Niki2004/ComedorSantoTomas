using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCU_Comedor.Models;

namespace TCU_Comedor.Controllers
{
    public class GaleriaController : Controller
    {
        private ApplicationDbContext BaseDatos = new ApplicationDbContext();
        
        [Authorize(Roles = "Chef")]
        public ActionResult Index()
        {
            var galeria = BaseDatos.Galeria
            .Include("AgendaAlimenticia")
            .ToList();

            return View(galeria);
        }

        [Authorize(Roles = "Chef")]
        [HttpGet]
        public ActionResult CrearGale()
        {
            ViewBag.Categorias = new SelectList(BaseDatos.AgendaAlimenticia, "Id_AgendaAlimenticia", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearGale(Galeria galeria)
        {
            if (ModelState.IsValid)
            {
                BaseDatos.Galeria.Add(galeria);
                BaseDatos.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categorias = new SelectList(BaseDatos.AgendaAlimenticia, "Id_AgendaAlimenticia", "Nombre", galeria.Id_Galeria);
            return View(galeria);
        }
    }
}