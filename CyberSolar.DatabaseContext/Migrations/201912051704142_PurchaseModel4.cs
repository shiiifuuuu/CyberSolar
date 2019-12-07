namespace CyberSolar.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseModel4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchasedProductInformations", "Product_Id", "dbo.Products");
            DropIndex("dbo.PurchasedProductInformations", new[] { "Product_Id" });
            DropColumn("dbo.PurchasedProductInformations", "ProductId");
            RenameColumn(table: "dbo.PurchasedProductInformations", name: "Product_Id", newName: "ProductId");
            AlterColumn("dbo.PurchasedProductInformations", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchasedProductInformations", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.PurchasedProductInformations", "ProductId");
            AddForeignKey("dbo.PurchasedProductInformations", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchasedProductInformations", "ProductId", "dbo.Products");
            DropIndex("dbo.PurchasedProductInformations", new[] { "ProductId" });
            AlterColumn("dbo.PurchasedProductInformations", "ProductId", c => c.Int());
            AlterColumn("dbo.PurchasedProductInformations", "ProductId", c => c.String());
            RenameColumn(table: "dbo.PurchasedProductInformations", name: "ProductId", newName: "Product_Id");
            AddColumn("dbo.PurchasedProductInformations", "ProductId", c => c.String());
            CreateIndex("dbo.PurchasedProductInformations", "Product_Id");
            AddForeignKey("dbo.PurchasedProductInformations", "Product_Id", "dbo.Products", "Id");
        }
    }
}
