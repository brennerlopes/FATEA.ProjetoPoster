namespace FATEA.ProjetoPoster.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CursoTableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CUR_CURSOS",
                c => new
                    {
                        CUR_ID = c.Int(nullable: false, identity: true),
                        CUR_NOME = c.String(nullable: false, maxLength: 150),
                        CUR_AREA = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CUR_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CUR_CURSOS");
        }
    }
}
