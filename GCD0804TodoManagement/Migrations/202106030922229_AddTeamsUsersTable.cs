namespace GCD0804TodoManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeamsUsersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeamUsers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.TeamId })
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TeamUsers", "TeamId", "dbo.Teams");
            DropIndex("dbo.TeamUsers", new[] { "TeamId" });
            DropIndex("dbo.TeamUsers", new[] { "UserId" });
            DropTable("dbo.TeamUsers");
        }
    }
}
