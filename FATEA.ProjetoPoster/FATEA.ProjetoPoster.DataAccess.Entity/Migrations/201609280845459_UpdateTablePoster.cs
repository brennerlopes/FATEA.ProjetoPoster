namespace FATEA.ProjetoPoster.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateTablePoster : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.POS_POSTER", "POS_CURSO", c => c.Int(nullable: false));
            AddColumn("dbo.POS_POSTER", "POS_EVENTO", c => c.Int(nullable: false));
            AlterColumn("dbo.POS_POSTER", "POS_NOTA", c => c.Double());
            AlterColumn("dbo.POS_POSTER", "POS_ARQUIVO", c => c.String(nullable: false, maxLength: 80));
            CreateIndex("dbo.POS_POSTER", "POS_CURSO");
            CreateIndex("dbo.POS_POSTER", "POS_EVENTO");
            AddForeignKey("dbo.POS_POSTER", "POS_CURSO", "dbo.CUR_CURSOS", "CUR_ID");
            AddForeignKey("dbo.POS_POSTER", "POS_EVENTO", "dbo.EVN_EVENTO", "EVN_ID");
            DropColumn("dbo.POS_POSTER", "POS_AREA");
        }

        public override void Down()
        {
            AddColumn("dbo.POS_POSTER", "POS_AREA", c => c.String(nullable: false, maxLength: 80));
            DropForeignKey("dbo.POS_POSTER", "POS_EVENTO", "dbo.EVN_EVENTO");
            DropForeignKey("dbo.POS_POSTER", "POS_CURSO", "dbo.CUR_CURSOS");
            DropIndex("dbo.POS_POSTER", new[] { "POS_EVENTO" });
            DropIndex("dbo.POS_POSTER", new[] { "POS_CURSO" });
            AlterColumn("dbo.POS_POSTER", "POS_ARQUIVO", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.POS_POSTER", "POS_NOTA", c => c.Double(nullable: false));
            DropColumn("dbo.POS_POSTER", "POS_EVENTO");
            DropColumn("dbo.POS_POSTER", "POS_CURSO");
        }
    }
}
