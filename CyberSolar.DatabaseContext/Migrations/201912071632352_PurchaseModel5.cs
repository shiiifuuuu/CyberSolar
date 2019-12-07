namespace CyberSolar.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseModel5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchasedProductInformations", "PurchaseInformationId", "dbo.PurchaseInformations");
            DropIndex("dbo.PurchasedProductInformations", new[] { "PurchaseInformationId" });
            AddColumn("dbo.PurchaseInformations", "PurchasedProduct_Id", c => c.Int());
            CreateIndex("dbo.PurchaseInformations", "PurchasedProduct_Id");
            AddForeignKey("dbo.PurchaseInformations", "PurchasedProduct_Id", "dbo.PurchasedProductInformations", "Id");
            DropColumn("dbo.PurchasedProductInformations", "PurchaseInformationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchasedProductInformations", "PurchaseInformationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PurchaseInformations", "PurchasedProduct_Id", "dbo.PurchasedProductInformations");
            DropIndex("dbo.PurchaseInformations", new[] { "PurchasedProduct_Id" });
            DropColumn("dbo.PurchaseInformations", "PurchasedProduct_Id");
            CreateIndex("dbo.PurchasedProductInformations", "PurchaseInformationId");
            AddForeignKey("dbo.PurchasedProductInformations", "PurchaseInformationId", "dbo.PurchaseInformations", "Id", cascadeDelete: true);
        }
    }
}
