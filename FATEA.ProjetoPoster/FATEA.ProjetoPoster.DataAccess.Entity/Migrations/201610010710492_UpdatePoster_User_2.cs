namespace FATEA.ProjetoPoster.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdatePoster_User_2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.POS_POSTER", name: "POS_USER", newName: "IdUsuario");
            AlterColumn("dbo.POS_POSTER", "IdUsuario", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.POS_POSTER", "IdUsuario", c => c.String(nullable: false));
            RenameColumn(table: "dbo.POS_POSTER", name: "IdUsuario", newName: "POS_USER");
        }
    }
}
