namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "gallery_GalleryId", "dbo.Galleries");
            DropIndex("dbo.Events", new[] { "gallery_GalleryId" });
            DropColumn("dbo.Events", "galleyId");
            RenameColumn(table: "dbo.Events", name: "gallery_GalleryId", newName: "galleyId");
            AlterColumn("dbo.Events", "galleyId", c => c.Int(nullable: true));
            CreateIndex("dbo.Events", "galleyId");
            AddForeignKey("dbo.Events", "galleyId", "dbo.Galleries", "GalleryId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "galleyId", "dbo.Galleries");
            DropIndex("dbo.Events", new[] { "galleyId" });
            AlterColumn("dbo.Events", "galleyId", c => c.Int());
            RenameColumn(table: "dbo.Events", name: "galleyId", newName: "gallery_GalleryId");
            AddColumn("dbo.Events", "galleyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "gallery_GalleryId");
            AddForeignKey("dbo.Events", "gallery_GalleryId", "dbo.Galleries", "GalleryId");
        }
    }
}
