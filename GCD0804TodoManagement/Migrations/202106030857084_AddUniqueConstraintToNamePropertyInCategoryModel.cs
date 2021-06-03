namespace GCD0804TodoManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueConstraintToNamePropertyInCategoryModel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Categories", "Name", unique: true, name: "Name_Index");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", "Name_Index");
        }
    }
}
