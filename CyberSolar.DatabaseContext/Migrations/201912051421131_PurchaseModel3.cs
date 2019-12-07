namespace CyberSolar.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseModel3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchasedProductInformations", "ManufacturedDate", c => c.DateTime());
            AlterColumn("dbo.PurchasedProductInformations", "ExpireDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchasedProductInformations", "ExpireDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PurchasedProductInformations", "ManufacturedDate", c => c.DateTime(nullable: false));
        }
    }
}
