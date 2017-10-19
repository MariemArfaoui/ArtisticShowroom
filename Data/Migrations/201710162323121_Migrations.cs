namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artworks",
                c => new
                    {
                        ArtworkId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DateAjout = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Price = c.Single(nullable: false),
                        Size = c.String(),
                        Material = c.String(),
                        User = c.String(),
                        Image = c.String(),
                        subCategory_SubCategoryId = c.Int(),
                        VenteAuxEncheres_VenteId = c.Int(),
                    })
                .PrimaryKey(t => t.ArtworkId)
                .ForeignKey("dbo.SubCategories", t => t.subCategory_SubCategoryId)
                .ForeignKey("dbo.VenteAuxEncheres", t => t.VenteAuxEncheres_VenteId)
                .Index(t => t.subCategory_SubCategoryId)
                .Index(t => t.VenteAuxEncheres_VenteId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.SubCategoryId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.VenteAuxEncheres",
                c => new
                    {
                        VenteId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Estimation = c.String(),
                        Duration = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        MinPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.VenteId);
            
            CreateTable(
                "dbo.Associations",
                c => new
                    {
                        AssociationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address_StreetAddress = c.String(maxLength: 200),
                        Address_City = c.String(nullable: false),
                        Description = c.String(),
                        VenteAuxEncheres_VenteId = c.Int(),
                    })
                .PrimaryKey(t => t.AssociationId)
                .ForeignKey("dbo.VenteAuxEncheres", t => t.VenteAuxEncheres_VenteId)
                .Index(t => t.VenteAuxEncheres_VenteId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Title = c.String(),
                        Description = c.String(),
                        Address_StreetAddress = c.String(maxLength: 200),
                        Address_City = c.String(nullable: false),
                        Gallery_GalleryId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Galleries", t => t.Gallery_GalleryId)
                .Index(t => t.Gallery_GalleryId);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleryId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Name = c.String(),
                        NumTel = c.Int(nullable: false),
                        description = c.String(),
                        Owner = c.String(),
                    })
                .PrimaryKey(t => t.GalleryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Gallery_GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Associations", "VenteAuxEncheres_VenteId", "dbo.VenteAuxEncheres");
            DropForeignKey("dbo.Artworks", "VenteAuxEncheres_VenteId", "dbo.VenteAuxEncheres");
            DropForeignKey("dbo.Artworks", "subCategory_SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Events", new[] { "Gallery_GalleryId" });
            DropIndex("dbo.Associations", new[] { "VenteAuxEncheres_VenteId" });
            DropIndex("dbo.SubCategories", new[] { "Category_CategoryId" });
            DropIndex("dbo.Artworks", new[] { "VenteAuxEncheres_VenteId" });
            DropIndex("dbo.Artworks", new[] { "subCategory_SubCategoryId" });
            DropTable("dbo.Galleries");
            DropTable("dbo.Events");
            DropTable("dbo.Associations");
            DropTable("dbo.VenteAuxEncheres");
            DropTable("dbo.Categories");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Artworks");
        }
    }
}
