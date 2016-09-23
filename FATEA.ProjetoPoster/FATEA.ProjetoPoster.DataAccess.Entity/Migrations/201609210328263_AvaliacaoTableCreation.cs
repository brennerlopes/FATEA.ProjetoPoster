namespace FATEA.ProjetoPoster.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AvaliacaoTableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AVA_AVALIACAO",
                c => new
                    {
                        AVA_ID = c.Long(nullable: false, identity: true),
                        AVA_NOTA_TEMA = c.Int(nullable: false),
                        AVA_NOTA_INTRODUCAO = c.Int(nullable: false),
                        AVA_NOTA_DESENVOLVIMENTO = c.Int(nullable: false),
                        AVA_NOTA_RESULTADOS = c.Int(nullable: false),
                        AVA_NOTA_CONCLUSAO = c.Int(nullable: false),
                        AVA_NOTA_FINAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        POS_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AVA_ID)
                .ForeignKey("dbo.POS_POSTER", t => t.POS_ID)
                .Index(t => t.POS_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AVA_AVALIACAO", "POS_ID", "dbo.POS_POSTER");
            DropIndex("dbo.AVA_AVALIACAO", new[] { "POS_ID" });
            DropTable("dbo.AVA_AVALIACAO");
        }
    }
}
