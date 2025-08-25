using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCU_Comedor.Models;

namespace TCU_Comedor.Controllers
{
    public class UsuariosController : Controller
    {
        private ApplicationDbContext BaseDatos = new ApplicationDbContext();

        [Authorize(Roles = "Administrador")]
        public ActionResult IndexUsuarios()
        {
            var usuarios = (from u in BaseDatos.Users
                            join ur in BaseDatos.Set<IdentityUserRole>() on u.Id equals ur.UserId
                            join r in BaseDatos.Roles on ur.RoleId equals r.Id
                            where r.Name == "Usuario"
                            select u).ToList();

            return View(usuarios);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult IndexNutricion(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                // si no hay id, mejor no mostrar nada o redirigir
                return RedirectToAction("IndexUsuarios");
            }

            var consultas = BaseDatos.ConsultaNutricional
                                     .Where(c => c.Id == id) 
                                     .ToList();

            return View(consultas);
        }

        [Authorize(Roles = "Administrador,Usuario")]
        public ActionResult IndexConsultas()
        {
            var consultas = BaseDatos.ConsultaServicio
                              .Include("ApplicationUser") // incluir la navegación
                              .ToList();

            return View(consultas);
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,Usuario")] 
        public ActionResult CrearConsultas()
        {
            // opcional: mostrar el nombre en la vista
            var userId = User.Identity.GetUserId();
            var user = BaseDatos.Users.FirstOrDefault(u => u.Id == userId);

            ViewBag.NombreUsuario = user?.NombreCompleto;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador,Usuario")]
        public ActionResult CrearConsultas(ConsultaServicio consultaServicio)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();  // Id del usuario logueado
                consultaServicio.Id = userId;            // asignar al modelo

                BaseDatos.ConsultaServicio.Add(consultaServicio);
                BaseDatos.SaveChanges();
                return RedirectToAction("IndexConsultas");
            }

            return View(consultaServicio);
        }

        [Authorize(Roles = "Administrador,Usuario,Chef")]
        public ActionResult Perfil()
        {
            var usuarios = (from u in BaseDatos.Users
                            join ur in BaseDatos.Set<IdentityUserRole>() on u.Id equals ur.UserId
                            join r in BaseDatos.Roles on ur.RoleId equals r.Id
                            where r.Name == "Usuario"
                            select u).ToList();

            return View(usuarios);
        }

    }
}