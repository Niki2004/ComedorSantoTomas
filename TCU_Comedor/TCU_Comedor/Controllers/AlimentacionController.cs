using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCU_Comedor.Models;

namespace TCU_Comedor.Controllers
{
    public class AlimentacionController : Controller
    {
        private ApplicationDbContext BaseDatos = new ApplicationDbContext();

        [Authorize(Roles = "Usuario")]
        public ActionResult Index()
        {
            var monitoreo = BaseDatos.MonitoreoAlimenticio.Include("Menu").ToList();

            return View(monitoreo);
        }

        [Authorize(Roles = "Usuario")]
        public ActionResult IndexInforme()
        {
            var personal = BaseDatos.PersonalizacionAlimentaria.Include("ApplicationUser").ToList();

            return View(personal);
        }

        [Authorize(Roles = "Usuario")]
        public ActionResult CreateInforme()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateInforme(PersonalizacionAlimentaria modelo)
        {
            if (ModelState.IsValid)
            {

                modelo.Id = User.Identity.GetUserId();

                BaseDatos.PersonalizacionAlimentaria.Add(modelo);
                BaseDatos.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        [Authorize(Roles = "Usuario")]
        public ActionResult nutriInfo()
        {
            var personal = BaseDatos.Nutricion.Include("ApplicationUser").ToList();

            return View(personal);
        }

        [Authorize(Roles = "Usuario")]
        public ActionResult CreatenutriInfo()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatenutriInfo(Nutricion modelo)
        {
            if (ModelState.IsValid)
            {
               
                modelo.Id = User.Identity.GetUserId();

                BaseDatos.Nutricion.Add(modelo);
                BaseDatos.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelo);
        }
    }
}