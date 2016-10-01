namespace FATEA.ProjetoPoster.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdatePoster_User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NomeUsuario = c.String(),
                        RgUsuario = c.String(),
                        CpfUsuario = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);

            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);

            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Usuario_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.Usuario_Id)
                .Index(t => t.IdentityRole_Id);

            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.POS_POSTER", "POS_USER", c => c.String(nullable: false));
            AddColumn("dbo.POS_POSTER", "Usuario_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.POS_POSTER", "Usuario_Id");
            AddForeignKey("dbo.POS_POSTER", "Usuario_Id", "dbo.Usuarios", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.IdentityUserRoles", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.POS_POSTER", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.IdentityUserLogins", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.IdentityUserClaims", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "Usuario_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "Usuario_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "Usuario_Id" });
            DropIndex("dbo.POS_POSTER", new[] { "Usuario_Id" });
            DropColumn("dbo.POS_POSTER", "Usuario_Id");
            DropColumn("dbo.POS_POSTER", "POS_USER");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.Usuarios");
        }
    }
}
