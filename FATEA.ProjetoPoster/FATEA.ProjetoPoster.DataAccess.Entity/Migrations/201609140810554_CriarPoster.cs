namespace FATEA.ProjetoPoster.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CriarPoster : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.POS_POSTER", name: "Autores", newName: "POS_AUTORES");
            RenameColumn(table: "dbo.POS_POSTER", name: "Area", newName: "POS_AREA");
            RenameColumn(table: "dbo.POS_POSTER", name: "AvaliadoPor", newName: "POS_AVALIADOR");
            AlterColumn("dbo.POS_POSTER", "POS_AUTORES", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.POS_POSTER", "POS_AREA", c => c.String(nullable: false, maxLength: 80));
        }

        public override void Down()
        {
            AlterColumn("dbo.POS_POSTER", "POS_AREA", c => c.String());
            AlterColumn("dbo.POS_POSTER", "POS_AUTORES", c => c.String());
            RenameColumn(table: "dbo.POS_POSTER", name: "POS_AVALIADOR", newName: "AvaliadoPor");
            RenameColumn(table: "dbo.POS_POSTER", name: "POS_AREA", newName: "Area");
            RenameColumn(table: "dbo.POS_POSTER", name: "POS_AUTORES", newName: "Autores");
        }
    }
}
