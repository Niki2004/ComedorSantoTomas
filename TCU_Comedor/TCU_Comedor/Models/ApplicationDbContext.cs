using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TCU_Comedor.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //Tabla para la base de datos Esto hace la conexión
        public DbSet<AgendaAlimenticia> AgendaAlimenticia { get; set; }
        public DbSet<Alergia> Alergia { get; set; }
        public DbSet<CategoriaAlimento> CategoriaAlimento { get; set; }
        public DbSet<CategoriaDietetica> CategoriaDietetica { get; set; }
        public DbSet<CategoriaMenu> CategoriaMenu { get; set; }
        public DbSet<CategoriaProveedor> CategoriaProveedor { get; set; }
        public DbSet<ConsultaNutricional> ConsultaNutricional { get; set; }
        public DbSet<ConsultaServicio> ConsultaServicio { get; set; }
        public DbSet<DocumentoPDF> DocumentoPDF { get; set; }
        public DbSet<ExperienciaNutricional> ExperienciaNutricional { get; set; }
        public DbSet<Galeria> Galeria { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MonitoreoAlimenticio> MonitoreoAlimenticio { get; set; }
        public DbSet<Nutricion> Nutricion { get; set; }
        public DbSet<PersonalizacionAlimentaria> PersonalizacionAlimentaria { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Tabla para la base de datos Esto hace la conexión
            modelBuilder.Entity<AgendaAlimenticia>().ToTable("AgendaAlimenticia");
            modelBuilder.Entity<Alergia>().ToTable("Alergia");
            modelBuilder.Entity<CategoriaAlimento>().ToTable("CategoriaAlimento");
            modelBuilder.Entity<CategoriaDietetica>().ToTable("CategoriaDietetica");
            modelBuilder.Entity<CategoriaMenu>().ToTable("CategoriaMenu");
            modelBuilder.Entity<CategoriaProveedor>().ToTable("CategoriaProveedor");
            modelBuilder.Entity<ConsultaNutricional>().ToTable("ConsultaNutricional");
            modelBuilder.Entity<ConsultaServicio>().ToTable("ConsultaServicio");
            modelBuilder.Entity<DocumentoPDF>().ToTable("DocumentoPDF");
            modelBuilder.Entity<ExperienciaNutricional>().ToTable("ExperienciaNutricional");
            modelBuilder.Entity<Galeria>().ToTable("Galeria");
            modelBuilder.Entity<Menu>().ToTable("Menu");
            modelBuilder.Entity<MonitoreoAlimenticio>().ToTable("MonitoreoAlimenticio");
            modelBuilder.Entity<Nutricion>().ToTable("Nutricion");
            modelBuilder.Entity<PersonalizacionAlimentaria>().ToTable("PersonalizacionAlimentaria");
            modelBuilder.Entity<Proveedor>().ToTable("Proveedor");

        }

        public System.Data.Entity.DbSet<TCU_Comedor.Models.ApplicationRol> IdentityRoles { get; set; }

    }
}