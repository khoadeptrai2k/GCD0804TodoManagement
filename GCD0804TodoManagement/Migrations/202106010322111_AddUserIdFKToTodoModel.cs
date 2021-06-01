namespace GCD0804TodoManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdFKToTodoModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Todoes", "UserId");
            AddForeignKey("dbo.Todoes", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Todoes", new[] { "UserId" });
            DropColumn("dbo.Todoes", "UserId");
        }
    }
}
