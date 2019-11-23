namespace CyberSolar.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductAvailableQuantityAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "AvailableQuantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "AvailableQuantity");
        }
    }
}
