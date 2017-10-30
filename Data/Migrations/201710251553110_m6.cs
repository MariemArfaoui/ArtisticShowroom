namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "qrcodeUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "qrcodeUrl");
        }
    }
}
