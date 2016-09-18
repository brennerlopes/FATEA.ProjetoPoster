namespace FATEA.ProjetoPoster.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PosterTableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instituicaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cidade = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.POS_POSTER",
                c => new
                    {
                        POS_ID = c.Int(nullable: false, identity: true),
                        POS_TITULO = c.String(nullable: false, maxLength: 100),
                        POS_AUTORES = c.String(nullable: false, maxLength: 150),
                        POS_PALAVRACHAVE = c.String(nullable: false, maxLength: 80),
                        POS_RESUMO = c.String(nullable: false, maxLength: 450),
                        POS_MODALIDADE = c.String(nullable: false, maxLength: 100),
                        POS_AREA = c.String(nullable: false, maxLength: 80),
                        POS_NOTA = c.Double(nullable: false),
                        POS_AVALIADOR = c.String(),
                        POS_ARQUIVO = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.POS_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.POS_POSTER");
            DropTable("dbo.Instituicaos");
        }
    }
}
