using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCU_Comedor.Models;

namespace TCU_Comedor.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext BaseDatos = new ApplicationDbContext();

        // GET: Menu
        [Authorize(Roles = "Usuario")]
        public ActionResult Index()
        {
            var menus = BaseDatos.Menu
             .Include("CategoriaMenu")
            .ToList();

            return View(menus);
        }

        [Authorize(Roles = "Chef")]
        public ActionResult IndexChef()
        {
            var menus = BaseDatos.Menu
             .Include("CategoriaMenu")
            .ToList();

            return View(menus);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult IndexADM()
        {
            var menus = BaseDatos.Menu
             .Include("CategoriaMenu")
            .ToList();

            return View(menus);
        }

        [Authorize(Roles = "Chef")]
        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.Categorias = new SelectList(BaseDatos.CategoriaMenu, "Id_CategoriaMenu", "Descripcion");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Menu menu)
        {
            if (ModelState.IsValid)
            {
                BaseDatos.Menu.Add(menu);
                BaseDatos.SaveChanges();
                return RedirectToAction("IndexChef");
            }

            ViewBag.Categorias = new SelectList(BaseDatos.CategoriaMenu, "Id_CategoriaMenu", "Descripcion", menu.Id_CategoriaMenu);
            return View(menu);
        }

    }
}