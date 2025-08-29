namespace TCU_Comedor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FechasNutricion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nutricion", "FechaNutricion", c => c.DateTime(nullable: false));
            AddColumn("dbo.PersonalizacionAlimentaria", "FechaPersonalizacion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonalizacionAlimentaria", "FechaPersonalizacion");
            DropColumn("dbo.Nutricion", "FechaNutricion");
        }
    }
}
