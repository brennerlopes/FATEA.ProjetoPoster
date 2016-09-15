namespace FATEA.ProjetoPoster.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddDB : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AVA_AREA", newName: "AVA_AVALIADOR");
            RenameColumn(table: "dbo.AVA_AVALIADOR", name: "Id", newName: "AVA_ID");
        }

        public override void Down()
        {
            RenameColumn(table: "dbo.AVA_AVALIADOR", name: "AVA_ID", newName: "Id");
            RenameTable(name: "dbo.AVA_AVALIADOR", newName: "AVA_AREA");
        }
    }
}
