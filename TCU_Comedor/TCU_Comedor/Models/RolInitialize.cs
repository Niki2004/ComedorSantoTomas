﻿using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class RolInitialize
    {
        public static void Inicializar()
        {
            var rolManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            //Roles 
            List<String> roles = new List<String>();
            roles.Add("Administrador");
            roles.Add("Usuario");
            roles.Add("Chef");

            foreach (var role in roles)
            {
                if (!rolManager.RoleExists(role))
                {
                    rolManager.Create(new IdentityRole(role));
                }
            }

            //usuario por defecto
            var adminUser = new ApplicationUser { Email = "carmenHidalgo01@es.mep.com" };
            String contra = "E1St3in@lSD001!";

            if (userManager.FindByEmail(adminUser.Email) == null)
            {
                var creacion = userManager.Create(adminUser, contra);
                if (creacion.Succeeded)
                {
                    userManager.AddToRole(adminUser.Id, "Usuario");
                }
            }
        }
    }
}