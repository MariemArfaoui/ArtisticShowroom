namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "imageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "imageURL");
        }
    }
}
