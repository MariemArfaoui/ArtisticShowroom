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
                        VenteId = c.Int(nullable: false),
                        subCategory_SubCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ArtworkId)
                .ForeignKey("dbo.VenteAuxEncheres", t => t.VenteId)
                .ForeignKey("dbo.SubCategories", t => t.subCategory_SubCategoryId)
                .Index(t => t.VenteId)
                .Index(t => t.subCategory_SubCategoryId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                        Description = c.String(nullable: false),
                        UserId = c.Int(),
                        User = c.String(nullable: false),
                        Category_CategoryId = c.Int(),
                        VenteAuxEncheres_VenteId = c.Int(),
                    })
                .PrimaryKey(t => t.SubCategoryId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .ForeignKey("dbo.VenteAuxEncheres", t => t.VenteAuxEncheres_VenteId)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.VenteAuxEncheres_VenteId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Extension = c.String(),
                        ContentType = c.String(),
                        ContentLength = c.Int(nullable: false),
                        ImageArray = c.Binary(),
                        ItemId = c.Int(),
                        SubCategory_SubCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubCategories", t => t.SubCategory_SubCategoryId)
                .Index(t => t.SubCategory_SubCategoryId);
            
            CreateTable(
                "dbo.VenteAuxEncheres",
                c => new
                    {
                        VenteId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 60),
                        Description = c.String(),
                        DateClose = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Estimation = c.String(),
                        Duration = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateOpen = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        MinPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                        Image = c.String(),
                        VenteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssociationId)
                .ForeignKey("dbo.VenteAuxEncheres", t => t.VenteId)
                .Index(t => t.VenteId);
            
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
            DropForeignKey("dbo.Artworks", "subCategory_SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "VenteAuxEncheres_VenteId", "dbo.VenteAuxEncheres");
            DropForeignKey("dbo.Associations", "VenteId", "dbo.VenteAuxEncheres");
            DropForeignKey("dbo.Artworks", "VenteId", "dbo.VenteAuxEncheres");
            DropForeignKey("dbo.Images", "SubCategory_SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Events", new[] { "Gallery_GalleryId" });
            DropIndex("dbo.Associations", new[] { "VenteId" });
            DropIndex("dbo.Images", new[] { "SubCategory_SubCategoryId" });
            DropIndex("dbo.SubCategories", new[] { "VenteAuxEncheres_VenteId" });
            DropIndex("dbo.SubCategories", new[] { "Category_CategoryId" });
            DropIndex("dbo.Artworks", new[] { "subCategory_SubCategoryId" });
            DropIndex("dbo.Artworks", new[] { "VenteId" });
            DropTable("dbo.Galleries");
            DropTable("dbo.Events");
            DropTable("dbo.Associations");
            DropTable("dbo.VenteAuxEncheres");
            DropTable("dbo.Images");
            DropTable("dbo.Categories");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Artworks");
        }
    }
}
