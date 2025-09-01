using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCU_Comedor.Models;

namespace TCU_Comedor.Controllers
{
    public class CategoriaController : Controller
    {
        private ApplicationDbContext BaseDatos = new ApplicationDbContext();

        [Authorize(Roles = "Chef")]
        public ActionResult Index()
        {
            var galeria = BaseDatos.CategoriaAlimento
            .Include("Nutricion")
            .ToList();

            return View(galeria);
        }

        [Authorize(Roles = "Chef")]
        [HttpGet]
        public ActionResult CrearCategoria()
        {
            ViewBag.Categorias = new SelectList(BaseDatos.Nutricion, "Id_Nutricion", "Detalle");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearCategoria(CategoriaAlimento categoriaAlimento)
        {
            if (ModelState.IsValid)
            {
                BaseDatos.CategoriaAlimento.Add(categoriaAlimento);
                BaseDatos.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categorias = new SelectList(BaseDatos.Nutricion, "Id_Nutricion", "Detalle", categoriaAlimento.Id_CategoriaAlimento);
            return View(categoriaAlimento);
        }
    }
}