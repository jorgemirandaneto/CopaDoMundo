namespace CopaDoMundo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JogadoresRequeridos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jogadores", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Jogadores", "Posicao", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jogadores", "Posicao", c => c.String());
            AlterColumn("dbo.Jogadores", "Nome", c => c.String());
        }
    }
}
