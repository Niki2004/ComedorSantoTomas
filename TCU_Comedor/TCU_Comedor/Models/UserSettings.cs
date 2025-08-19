using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class UserSettings
    {
        [Key]
        public int Id_UserSettings { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string Theme { get; set; }
        public int FontSize { get; set; }
        public bool MenuNotifications { get; set; }
        public bool MealReminders { get; set; }
        public int ReminderTime { get; set; }
        public string DietaryRestrictions { get; set; }
        public string PortionSize { get; set; }
        public bool ShareData { get; set; }
    }
}