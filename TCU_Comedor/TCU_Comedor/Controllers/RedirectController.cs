using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TCU_Comedor.Models;

namespace TCU_Comedor.Controllers
{
    public class RedirectController : Controller
    {
        private ApplicationUserManager _userManager;
        private readonly ApplicationDbContext _context;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public RedirectController()
        {
            _context = new ApplicationDbContext();
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // GET: Redirect

        public async Task<ActionResult> Redirect(String email)
        {
            if (!User.Identity.IsAuthenticated)
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                return RedirectToAction("Login", "Account");
            }

            var user = await UserManager.FindByEmailAsync(email);

            if (User.IsInRole("Administrador"))
                return RedirectToAction("IndAdministrador", "RolesPropuestos");

            else if (User.IsInRole("Usuario"))
                return RedirectToAction("IndUsuario", "RolesPropuestos");

            else if (User.IsInRole("Chef"))
                return RedirectToAction("IndChef", "RolesPropuestos");


            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            ModelState.AddModelError("", "El usuario no tiene un rol válido");
            return RedirectToAction("Login", "Account");
        }
    }
}