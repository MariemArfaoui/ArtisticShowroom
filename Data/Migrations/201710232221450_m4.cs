namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "galleyId", newName: "GalleryId");
            RenameIndex(table: "dbo.Events", name: "IX_galleyId", newName: "IX_GalleryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_GalleryId", newName: "IX_galleyId");
            RenameColumn(table: "dbo.Events", name: "GalleryId", newName: "galleyId");
        }
    }
}
