namespace CopaDoMundo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequeridoSelecao : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Selecoes", "Pais", c => c.String(nullable: false));
            AlterColumn("dbo.Selecoes", "Tecnico", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Selecoes", "Tecnico", c => c.String());
            AlterColumn("dbo.Selecoes", "Pais", c => c.String());
        }
    }
}
