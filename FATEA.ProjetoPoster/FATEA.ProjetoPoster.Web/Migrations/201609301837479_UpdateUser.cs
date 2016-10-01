namespace FATEA.ProjetoPoster.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EmailUsuario", newName: "AspNetUsers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "EmailUsuario");
        }
    }
}
