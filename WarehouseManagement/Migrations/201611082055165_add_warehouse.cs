namespace WarehouseManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_warehouse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        FreeSpace = c.Int(nullable: false),
                        Address = c.String(),
                        Location = c.Geography(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        StorageDate = c.DateTime(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        SoldDate = c.DateTime(nullable: false),
                        StoreID = c.Int(),
                        WarehouseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseID, cascadeDelete: true)
                .Index(t => t.StoreID)
                .Index(t => t.WarehouseID);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Purpose = c.String(maxLength: 50),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Address = c.String(),
                        Location = c.Geography(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "WarehouseID", "dbo.Warehouses");
            DropForeignKey("dbo.Products", "StoreID", "dbo.Stores");
            DropIndex("dbo.Products", new[] { "WarehouseID" });
            DropIndex("dbo.Products", new[] { "StoreID" });
            DropTable("dbo.Stores");
            DropTable("dbo.Products");
            DropTable("dbo.Warehouses");
        }
    }
}
