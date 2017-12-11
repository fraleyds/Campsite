namespace Campsite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InventoryEntity",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Condition = c.String(nullable: false, maxLength: 500),
                        IsAvailable = c.Boolean(nullable: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("dbo.OwnerEntity", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.OwnerEntity",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Contact = c.String(nullable: false, maxLength: 100),
                        OwnerRating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OwnerId);
            
            CreateTable(
                "dbo.ItemEntity",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        InventoryId = c.Int(nullable: false),
                        TransactionId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.InventoryEntity", t => t.InventoryId, cascadeDelete: true)
                .ForeignKey("dbo.TransactionEntity", t => t.TransactionId)
                .Index(t => t.InventoryId)
                .Index(t => t.TransactionId);
            
            CreateTable(
                "dbo.TransactionEntity",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        FinalPrice = c.Decimal(precision: 18, scale: 2),
                        RenterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.RenterEntity", t => t.RenterId, cascadeDelete: true)
                .Index(t => t.RenterId);
            
            CreateTable(
                "dbo.RenterEntity",
                c => new
                    {
                        RenterId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Contact = c.String(nullable: false, maxLength: 100),
                        RenterRating = c.Int(nullable: false),
                        IsRenting = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RenterId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        CampsiteUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.CampsiteUser", t => t.CampsiteUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.CampsiteUser_Id);
            
            CreateTable(
                "dbo.CampsiteUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        CampsiteUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CampsiteUser", t => t.CampsiteUser_Id)
                .Index(t => t.CampsiteUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        CampsiteUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.CampsiteUser", t => t.CampsiteUser_Id)
                .Index(t => t.CampsiteUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "CampsiteUser_Id", "dbo.CampsiteUser");
            DropForeignKey("dbo.IdentityUserLogin", "CampsiteUser_Id", "dbo.CampsiteUser");
            DropForeignKey("dbo.IdentityUserClaim", "CampsiteUser_Id", "dbo.CampsiteUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.ItemEntity", "TransactionId", "dbo.TransactionEntity");
            DropForeignKey("dbo.TransactionEntity", "RenterId", "dbo.RenterEntity");
            DropForeignKey("dbo.ItemEntity", "InventoryId", "dbo.InventoryEntity");
            DropForeignKey("dbo.InventoryEntity", "OwnerId", "dbo.OwnerEntity");
            DropIndex("dbo.IdentityUserLogin", new[] { "CampsiteUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "CampsiteUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "CampsiteUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.TransactionEntity", new[] { "RenterId" });
            DropIndex("dbo.ItemEntity", new[] { "TransactionId" });
            DropIndex("dbo.ItemEntity", new[] { "InventoryId" });
            DropIndex("dbo.InventoryEntity", new[] { "OwnerId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.CampsiteUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.RenterEntity");
            DropTable("dbo.TransactionEntity");
            DropTable("dbo.ItemEntity");
            DropTable("dbo.OwnerEntity");
            DropTable("dbo.InventoryEntity");
        }
    }
}
