namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galleries", "lat", c => c.Double(nullable: false));
            AddColumn("dbo.Galleries", "lng", c => c.Double(nullable: false));
            AddColumn("dbo.Galleries", "galleryImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Galleries", "galleryImage");
            DropColumn("dbo.Galleries", "lng");
            DropColumn("dbo.Galleries", "lat");
        }
    }
}
