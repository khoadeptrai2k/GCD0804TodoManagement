namespace GCD0804TodoManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeamsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "Name_Index");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Teams", "Name_Index");
            DropTable("dbo.Teams");
        }
    }
}
