using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSolar.MODEL.Model;

namespace CyberSolar.DatabaseContext.DatabaseContext
{
    public class ProjectDbContext: DbContext
    {
        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Supplier> Suppliers { set; get; }
        public DbSet<PurchaseInformation> PurchaseInformations { set; get; }
        public DbSet<PurchasedProductInformation> PurchasedProductInformations { set; get; }
    }
}
