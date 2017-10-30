namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        userId = c.Int(nullable: false),
                        eventId = c.Int(nullable: false),
                        ticketId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => new { t.userId, t.eventId, t.ticketId })
                .ForeignKey("dbo.Events", t => t.eventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId)
                .Index(t => t.eventId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        eventId = c.Int(nullable: false, identity: true),
                        startDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        endDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        actualDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        title = c.String(),
                        description = c.String(),
                        galleyId = c.Int(nullable: false),
                        inclusions = c.String(),
                        gallery_GalleryId = c.Int(),
                    })
                .PrimaryKey(t => t.eventId)
                .ForeignKey("dbo.Galleries", t => t.gallery_GalleryId)
                .Index(t => t.gallery_GalleryId);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleryId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Name = c.String(),
                        NumTel = c.Int(nullable: false),
                        description = c.String(),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GalleryId)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        role = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "userId", "dbo.Users");
            DropForeignKey("dbo.Bookings", "eventId", "dbo.Events");
            DropForeignKey("dbo.Events", "gallery_GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Galleries", "userId", "dbo.Users");
            DropIndex("dbo.Galleries", new[] { "userId" });
            DropIndex("dbo.Events", new[] { "gallery_GalleryId" });
            DropIndex("dbo.Bookings", new[] { "eventId" });
            DropIndex("dbo.Bookings", new[] { "userId" });
            DropTable("dbo.Users");
            DropTable("dbo.Galleries");
            DropTable("dbo.Events");
            DropTable("dbo.Bookings");
        }
    }
}
