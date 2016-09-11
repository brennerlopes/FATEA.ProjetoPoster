namespace FATEA.ProjetoPoster.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventoTableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EVN_EVENTO",
                c => new
                    {
                        EVN_ID = c.Int(nullable: false, identity: true),
                        EVN_NOME = c.String(nullable: false, maxLength: 100),
                        EVN_TEMA = c.String(nullable: false, maxLength: 100),
                        EVN_DESCRICAO = c.String(nullable: false, maxLength: 150),
                        EVN_NUMMAXIMOAUTORES = c.Int(nullable: false),
                        EVN_NUMAVALIADORES = c.Int(nullable: false),
                        EVN_STATUS = c.Boolean(nullable: false),
                        EVN_DATAINICIO = c.DateTime(nullable: false),
                        EVN_DATAFIM = c.DateTime(nullable: false),
                        EVN_INFORMACOES = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.EVN_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EVN_EVENTO");
        }
    }
}
