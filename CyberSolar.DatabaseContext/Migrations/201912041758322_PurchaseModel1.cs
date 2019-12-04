namespace CyberSolar.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchasedProductInformations", "PurchaseInformationId", c => c.Int(nullable: false));
            CreateIndex("dbo.PurchasedProductInformations", "PurchaseInformationId");
            AddForeignKey("dbo.PurchasedProductInformations", "PurchaseInformationId", "dbo.PurchaseInformations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchasedProductInformations", "PurchaseInformationId", "dbo.PurchaseInformations");
            DropIndex("dbo.PurchasedProductInformations", new[] { "PurchaseInformationId" });
            DropColumn("dbo.PurchasedProductInformations", "PurchaseInformationId");
        }
    }
}
