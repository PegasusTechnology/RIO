namespace RIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 500),
                        FirstName = c.String(nullable: false, maxLength: 500),
                        LastName = c.String(nullable: false, maxLength: 500),
                        EmailId = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Phone = c.Int(nullable: false),
                        Photo = c.String(maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AddressLine1 = c.String(nullable: false, maxLength: 500),
                        AddressLine2 = c.String(nullable: false, maxLength: 500),
                        AddressLine3 = c.String(maxLength: 500),
                        PinCode = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        BrandName = c.String(nullable: false, maxLength: 250),
                        SortOrder = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 1000),
                        SortOrder = c.Int(nullable: false),
                        HierarchyLevel = c.Int(nullable: false),
                        ParentCategoryId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Category", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        StateId = c.Int(nullable: false),
                        CityName = c.String(nullable: false, maxLength: 250),
                        SortOrder = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.State", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Costing",
                c => new
                    {
                        CostingId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CostingId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false, maxLength: 250),
                        SortOrder = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        StateName = c.String(nullable: false, maxLength: 250),
                        SortOrder = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StateId)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.EmailTemplate",
                c => new
                    {
                        EmailTemplateId = c.Int(nullable: false, identity: true),
                        TemplateCode = c.String(nullable: false, maxLength: 150),
                        From = c.String(maxLength: 150),
                        To = c.String(maxLength: 1000),
                        Cc = c.String(maxLength: 1000),
                        Bcc = c.String(maxLength: 1000),
                        Subject = c.String(maxLength: 500),
                        Body = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmailTemplateId);
            
            CreateTable(
                "dbo.IdentityProof",
                c => new
                    {
                        IdentityProofId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        SortOrder = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdentityProofId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        ItemName = c.String(nullable: false, maxLength: 150),
                        ItemDescription = c.String(maxLength: 1000),
                        Phone = c.Int(nullable: false),
                        PostedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Brand", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Address", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.BrandId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.ItemCosting",
                c => new
                    {
                        ItemCostingId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        CostingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemCostingId)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ItemRequiredDocument",
                c => new
                    {
                        ItemRequiredDocumentId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        IdentityProofId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemRequiredDocumentId)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ItemImage",
                c => new
                    {
                        ItemImageId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        ImagePath = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ItemImageId)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ItemRequest",
                c => new
                    {
                        ItemRequestId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        RequestorId = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                        RequestedDateFrom = c.DateTime(nullable: false),
                        RequestedDateTo = c.DateTime(nullable: false),
                        Remarks = c.Int(nullable: false),
                        RequestStatus = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ItemRequestId);
            
            CreateTable(
                "dbo.Configuration",
                c => new
                    {
                        ConfigurationId = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 250),
                        Value = c.String(nullable: false, maxLength: 1000),
                        Description = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.ConfigurationId);
            
            CreateTable(
                "dbo.UsageLog",
                c => new
                    {
                        UsageLogId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Url = c.String(maxLength: 500),
                        IPAddress = c.String(maxLength: 50),
                        ActionDetails = c.String(maxLength: 1000),
                        Device = c.String(maxLength: 50),
                        Browser = c.String(maxLength: 100),
                        LogDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UsageLogId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRating",
                c => new
                    {
                        UserRatingId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
                        ThumbsUp = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserRatingId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserRating", new[] { "UserId" });
            DropIndex("dbo.UsageLog", new[] { "UserId" });
            DropIndex("dbo.ItemImage", new[] { "ItemId" });
            DropIndex("dbo.ItemRequiredDocument", new[] { "ItemId" });
            DropIndex("dbo.ItemCosting", new[] { "ItemId" });
            DropIndex("dbo.Item", new[] { "AddressId" });
            DropIndex("dbo.Item", new[] { "BrandId" });
            DropIndex("dbo.Item", new[] { "CategoryId" });
            DropIndex("dbo.State", new[] { "CountryId" });
            DropIndex("dbo.City", new[] { "StateId" });
            DropIndex("dbo.Category", new[] { "ParentCategoryId" });
            DropIndex("dbo.Address", new[] { "UserId" });
            DropForeignKey("dbo.UserRating", "UserId", "dbo.User");
            DropForeignKey("dbo.UsageLog", "UserId", "dbo.User");
            DropForeignKey("dbo.ItemImage", "ItemId", "dbo.Item");
            DropForeignKey("dbo.ItemRequiredDocument", "ItemId", "dbo.Item");
            DropForeignKey("dbo.ItemCosting", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Item", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Item", "BrandId", "dbo.Brand");
            DropForeignKey("dbo.Item", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.State", "CountryId", "dbo.Country");
            DropForeignKey("dbo.City", "StateId", "dbo.State");
            DropForeignKey("dbo.Category", "ParentCategoryId", "dbo.Category");
            DropForeignKey("dbo.Address", "UserId", "dbo.User");
            DropTable("dbo.UserRating");
            DropTable("dbo.UsageLog");
            DropTable("dbo.Configuration");
            DropTable("dbo.ItemRequest");
            DropTable("dbo.ItemImage");
            DropTable("dbo.ItemRequiredDocument");
            DropTable("dbo.ItemCosting");
            DropTable("dbo.Item");
            DropTable("dbo.IdentityProof");
            DropTable("dbo.EmailTemplate");
            DropTable("dbo.State");
            DropTable("dbo.Country");
            DropTable("dbo.Costing");
            DropTable("dbo.City");
            DropTable("dbo.Category");
            DropTable("dbo.Brand");
            DropTable("dbo.Address");
            DropTable("dbo.User");
        }
    }
}
