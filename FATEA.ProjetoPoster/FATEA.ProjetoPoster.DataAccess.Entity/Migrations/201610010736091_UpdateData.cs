namespace FATEA.ProjetoPoster.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AVA_AVALIACAO", "AVL_ID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AVA_AVALIACAO", "AVL_ID");
        }
    }
}
