using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCU_Comedor.Models;

namespace TCU_Comedor.Controllers
{
    [Authorize]
    public class AjustesController : Controller
    {
        private ApplicationDbContext BaseDatos = new ApplicationDbContext();

        [Authorize(Roles = "Administrador, Chef, Usuario")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var settings = BaseDatos.UserSettings.FirstOrDefault(s => s.Id == userId);

            if (settings == null)
            {
                settings = new UserSettings
                {
                    Id = userId,
                    Theme = "light",
                    FontSize = 16,
                    MenuNotifications = true,
                    MealReminders = true,
                    ReminderTime = 30,
                    PortionSize = "medium",
                    ShareData = true,
                    DietaryRestrictions = ""
                };
                BaseDatos.UserSettings.Add(settings);
                BaseDatos.SaveChanges();
            }

            return View(settings);
        }

        [Authorize(Roles = "Administrador, Chef, Usuario")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Guardar()
        {
            try
            {
                var userId = User.Identity.GetUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    return Json(new { success = false, message = "Usuario no autenticado" });
                }

                var settings = BaseDatos.UserSettings.FirstOrDefault(s => s.Id == userId);
                if (settings == null)
                {
                    settings = new UserSettings { Id = userId };
                    BaseDatos.UserSettings.Add(settings);
                }

                // Obtener valores del formulario
                settings.Theme = Request.Form["Theme"] ?? "light";

                if (int.TryParse(Request.Form["FontSize"], out int fontSize))
                    settings.FontSize = fontSize;
                else
                    settings.FontSize = 16;

                if (bool.TryParse(Request.Form["MenuNotifications"], out bool menuNotifications))
                    settings.MenuNotifications = menuNotifications;
                else
                    settings.MenuNotifications = false;

                if (bool.TryParse(Request.Form["MealReminders"], out bool mealReminders))
                    settings.MealReminders = mealReminders;
                else
                    settings.MealReminders = false;

                if (int.TryParse(Request.Form["ReminderTime"], out int reminderTime))
                    settings.ReminderTime = reminderTime;
                else
                    settings.ReminderTime = 30;

                settings.PortionSize = Request.Form["PortionSize"] ?? "medium";

                if (bool.TryParse(Request.Form["ShareData"], out bool shareData))
                    settings.ShareData = shareData;
                else
                    settings.ShareData = false;

                settings.DietaryRestrictions = Request.Form["DietaryRestrictions"] ?? "";

                BaseDatos.SaveChanges();

                return Json(new { success = true, message = "Configuración guardada exitosamente" });
            }
            catch (Exception ex)
            {
                // Log the error (you should implement proper logging)
                System.Diagnostics.Debug.WriteLine($"Error saving settings: {ex.Message}");

                return Json(new { success = false, message = "Error interno del servidor" });
            }
        }

        [Authorize(Roles = "Administrador, Chef, Usuario")]
        [HttpGet]
        public JsonResult GetUserSettings()
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var settings = BaseDatos.UserSettings.FirstOrDefault(s => s.Id == userId);

                if (settings == null)
                {
                    settings = new UserSettings
                    {
                        Id = userId,
                        Theme = "light",
                        FontSize = 16,
                        MenuNotifications = true,
                        MealReminders = true,
                        ReminderTime = 30,
                        PortionSize = "medium",
                        ShareData = true,
                        DietaryRestrictions = ""
                    };
                }

                return Json(settings, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting settings: {ex.Message}");
                return Json(new { error = "Error al obtener configuraciones" }, JsonRequestBehavior.AllowGet);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                BaseDatos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}