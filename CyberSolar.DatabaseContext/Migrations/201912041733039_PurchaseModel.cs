namespace CyberSolar.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchasedProductInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.String(),
                        ManufacturedDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        Mrp = c.Double(nullable: false),
                        Remarks = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.PurchaseInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        InvoiceNo = c.String(),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseInformations", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchasedProductInformations", "Product_Id", "dbo.Products");
            DropIndex("dbo.PurchaseInformations", new[] { "SupplierId" });
            DropIndex("dbo.PurchasedProductInformations", new[] { "Product_Id" });
            DropTable("dbo.PurchaseInformations");
            DropTable("dbo.PurchasedProductInformations");
        }
    }
}
