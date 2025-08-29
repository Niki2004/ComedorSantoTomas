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
            // Definir el ID del usuario logueado
            string userId = User.Identity.GetUserId();

            var model = new AjustesViewModel
            {
                Informes = BaseDatos.PersonalizacionAlimentaria
                            .Include("ApplicationUser")
                            .Where(i => i.Id == userId)   
                            .ToList(),

                Nutriciones = BaseDatos.Nutricion
                              .Include("ApplicationUser")
                              .Where(n => n.Id == userId)  
                              .ToList()
            };

            return View(model);
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
                return RedirectToAction("IndexInforme");
            }
            return View(modelo);
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
                return RedirectToAction("IndexInforme");
            }

            return View(modelo);
        }
    }
}