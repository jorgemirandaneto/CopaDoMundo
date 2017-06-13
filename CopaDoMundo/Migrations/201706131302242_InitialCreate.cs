namespace CopaDoMundo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jogadores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Posicao = c.String(),
                        Nascimento = c.DateTime(nullable: false),
                        Altura = c.Double(nullable: false),
                        SelecaoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Selecoes", t => t.SelecaoId, cascadeDelete: true)
                .Index(t => t.SelecaoId);
            
            CreateTable(
                "dbo.Selecoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pais = c.String(),
                        Tecnico = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jogadores", "SelecaoId", "dbo.Selecoes");
            DropIndex("dbo.Jogadores", new[] { "SelecaoId" });
            DropTable("dbo.Selecoes");
            DropTable("dbo.Jogadores");
        }
    }
}
