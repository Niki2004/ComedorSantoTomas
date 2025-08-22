using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCU_Comedor.Controllers
{
    public class RolesPropuestosController : Controller
    {
        [Authorize(Roles = "Administrador")]
        public ActionResult IndAdministrador()
        {
            return View();
        }

        [Authorize(Roles = "Usuario")]
        public ActionResult IndUsuario()
        {
            return View();
        }

        [Authorize(Roles = "Chef")]
        public ActionResult IndChef()
        {
            return View();
        }

        [Authorize]
        public ActionResult Inicio()
        {
            if (User.IsInRole("Administrador"))
            {
                return RedirectToAction("IndAdministrador", "RolesPropuestos");
            }
            else if (User.IsInRole("Chef"))
            {
                return RedirectToAction("IndexChef", "RolesPropuestos");
            }
            else if (User.IsInRole("Usuario"))
            {
                return RedirectToAction("IndUsuario", "RolesPropuestos");
            }

            // En caso de no tener rol, lo mandas a login
            return RedirectToAction("Login", "Account");
        }

    }

}