namespace GCD0804TodoManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredForUserIdInTodoModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Todoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Todoes", new[] { "UserId" });
            AlterColumn("dbo.Todoes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Todoes", "UserId");
            AddForeignKey("dbo.Todoes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Todoes", new[] { "UserId" });
            AlterColumn("dbo.Todoes", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Todoes", "UserId");
            AddForeignKey("dbo.Todoes", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
