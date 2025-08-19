using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCU_Comedor.Models;

namespace TCU_Comedor.Controllers
{
    public class AjustesController : Controller
    {
        private ApplicationDbContext BaseDatos = new ApplicationDbContext();

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
                    ShareData = true
                };
                BaseDatos.UserSettings.Add(settings);
                BaseDatos.SaveChanges();
            }

            return View(settings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Guardar(UserSettings model)
        {
            var userId = User.Identity.GetUserId(); // o como manejes el usuario
            var settings = BaseDatos.UserSettings.FirstOrDefault(s => s.Id == userId);

            if (settings == null)
            {
                settings = new UserSettings { Id = userId };
                BaseDatos.UserSettings.Add(settings);
            }

            settings.Theme = model.Theme;
            settings.FontSize = model.FontSize;
            settings.MenuNotifications = model.MenuNotifications;
            settings.MealReminders = model.MealReminders;
            settings.ReminderTime = model.ReminderTime;
            settings.PortionSize = model.PortionSize;
            settings.DietaryRestrictions = string.Join(",", model.DietaryRestrictions);

            BaseDatos.SaveChanges();

            return Json(new { success = true });
        }

        [Authorize]
        public JsonResult GetUserSettings()
        {
            var userId = User.Identity.GetUserId();
            var settings = BaseDatos.UserSettings.FirstOrDefault(s => s.Id == userId);

            return Json(settings, JsonRequestBehavior.AllowGet);
        }
    }
}