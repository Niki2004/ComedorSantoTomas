namespace TCU_Comedor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgendaAlimenticia",
                c => new
                    {
                        Id_AgendaAlimenticia = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 100),
                        FechaAgendaAlimenticia = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id_AgendaAlimenticia);
            
            CreateTable(
                "dbo.Alergia",
                c => new
                    {
                        Id_Alergia = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        Alergias = c.Boolean(nullable: false),
                        DetalleAlergias = c.String(maxLength: 100),
                        Enfermedades = c.Boolean(nullable: false),
                        DetalleEnfermedades = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id_Alergia)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NombreCompleto = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CategoriaAlimento",
                c => new
                    {
                        Id_CategoriaAlimento = c.Int(nullable: false, identity: true),
                        Id_Nutricion = c.Int(nullable: false),
                        NombreCategoria = c.String(maxLength: 100),
                        Descripcion = c.String(maxLength: 100),
                        FechaRegistro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id_CategoriaAlimento)
                .ForeignKey("dbo.Nutricion", t => t.Id_Nutricion, cascadeDelete: true)
                .Index(t => t.Id_Nutricion);
            
            CreateTable(
                "dbo.Nutricion",
                c => new
                    {
                        Id_Nutricion = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        Detalle = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id_Nutricion)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CategoriaDietetica",
                c => new
                    {
                        Id_CategoriaDietetica = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        Tipo = c.String(maxLength: 100),
                        Detalles = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id_CategoriaDietetica)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CategoriaMenu",
                c => new
                    {
                        Id_CategoriaMenu = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id_CategoriaMenu);
            
            CreateTable(
                "dbo.CategoriaProveedor",
                c => new
                    {
                        Id_Alergia = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id_Alergia);
            
            CreateTable(
                "dbo.ConsultaNutricional",
                c => new
                    {
                        Id_ConsultaNutricional = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        Detalles = c.String(maxLength: 100),
                        FechaConsultaNutricional = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id_ConsultaNutricional)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ConsultaServicio",
                c => new
                    {
                        Id_ConsultaServicio = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        Detalle = c.String(maxLength: 100),
                        FechaExperienciaNutricional = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id_ConsultaServicio)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.DocumentoPDF",
                c => new
                    {
                        Id_DocumentoPDF = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 100),
                        Ruta = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id_DocumentoPDF);
            
            CreateTable(
                "dbo.ExperienciaNutricional",
                c => new
                    {
                        Id_ExperienciaNutricional = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        Experiencia = c.String(maxLength: 100),
                        FechaExperienciaNutricional = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id_ExperienciaNutricional)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Galeria",
                c => new
                    {
                        Id_Galeria = c.Int(nullable: false, identity: true),
                        Id_AgendaAlimenticia = c.Int(nullable: false),
                        FechaMenu = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Galeria)
                .ForeignKey("dbo.AgendaAlimenticia", t => t.Id_AgendaAlimenticia, cascadeDelete: true)
                .Index(t => t.Id_AgendaAlimenticia);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Descripcion = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id_Menu = c.Int(nullable: false, identity: true),
                        Id_CategoriaMenu = c.Int(nullable: false),
                        NombreComida = c.String(maxLength: 100),
                        FechaMenu = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Menu)
                .ForeignKey("dbo.CategoriaMenu", t => t.Id_CategoriaMenu, cascadeDelete: true)
                .Index(t => t.Id_CategoriaMenu);
            
            CreateTable(
                "dbo.MonitoreoAlimenticio",
                c => new
                    {
                        Id_MonitoreoAlimenticio = c.Int(nullable: false, identity: true),
                        Id_Menu = c.Int(nullable: false),
                        Observacion = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id_MonitoreoAlimenticio)
                .ForeignKey("dbo.Menu", t => t.Id_Menu, cascadeDelete: true)
                .Index(t => t.Id_Menu);
            
            CreateTable(
                "dbo.PersonalizacionAlimentaria",
                c => new
                    {
                        Id_PersonalizacionAlimentaria = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        Preferencias = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id_PersonalizacionAlimentaria)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        Id_Proveedor = c.Int(nullable: false, identity: true),
                        Id_CategoriaProveedor = c.Int(nullable: false),
                        Costos = c.String(),
                        NombreProveedor = c.String(maxLength: 100),
                        NumeroProveedor = c.String(maxLength: 100),
                        CorreoProveedor = c.String(),
                    })
                .PrimaryKey(t => t.Id_Proveedor)
                .ForeignKey("dbo.CategoriaProveedor", t => t.Id_CategoriaProveedor, cascadeDelete: true)
                .Index(t => t.Id_CategoriaProveedor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Proveedor", "Id_CategoriaProveedor", "dbo.CategoriaProveedor");
            DropForeignKey("dbo.PersonalizacionAlimentaria", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MonitoreoAlimenticio", "Id_Menu", "dbo.Menu");
            DropForeignKey("dbo.Menu", "Id_CategoriaMenu", "dbo.CategoriaMenu");
            DropForeignKey("dbo.Galeria", "Id_AgendaAlimenticia", "dbo.AgendaAlimenticia");
            DropForeignKey("dbo.ExperienciaNutricional", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ConsultaServicio", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ConsultaNutricional", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CategoriaDietetica", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CategoriaAlimento", "Id_Nutricion", "dbo.Nutricion");
            DropForeignKey("dbo.Nutricion", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Alergia", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Proveedor", new[] { "Id_CategoriaProveedor" });
            DropIndex("dbo.PersonalizacionAlimentaria", new[] { "Id" });
            DropIndex("dbo.MonitoreoAlimenticio", new[] { "Id_Menu" });
            DropIndex("dbo.Menu", new[] { "Id_CategoriaMenu" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Galeria", new[] { "Id_AgendaAlimenticia" });
            DropIndex("dbo.ExperienciaNutricional", new[] { "Id" });
            DropIndex("dbo.ConsultaServicio", new[] { "Id" });
            DropIndex("dbo.ConsultaNutricional", new[] { "Id" });
            DropIndex("dbo.CategoriaDietetica", new[] { "Id" });
            DropIndex("dbo.Nutricion", new[] { "Id" });
            DropIndex("dbo.CategoriaAlimento", new[] { "Id_Nutricion" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Alergia", new[] { "Id" });
            DropTable("dbo.Proveedor");
            DropTable("dbo.PersonalizacionAlimentaria");
            DropTable("dbo.MonitoreoAlimenticio");
            DropTable("dbo.Menu");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Galeria");
            DropTable("dbo.ExperienciaNutricional");
            DropTable("dbo.DocumentoPDF");
            DropTable("dbo.ConsultaServicio");
            DropTable("dbo.ConsultaNutricional");
            DropTable("dbo.CategoriaProveedor");
            DropTable("dbo.CategoriaMenu");
            DropTable("dbo.CategoriaDietetica");
            DropTable("dbo.Nutricion");
            DropTable("dbo.CategoriaAlimento");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Alergia");
            DropTable("dbo.AgendaAlimenticia");
        }
    }
}
