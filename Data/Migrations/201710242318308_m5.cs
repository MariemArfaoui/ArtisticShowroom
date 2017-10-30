namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "userId", c => c.Int(nullable: true));
            CreateIndex("dbo.Events", "userId");
            AddForeignKey("dbo.Events", "userId", "dbo.Users", "userId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "userId", "dbo.Users");
            DropIndex("dbo.Events", new[] { "userId" });
            DropColumn("dbo.Events", "userId");
        }
    }
}
