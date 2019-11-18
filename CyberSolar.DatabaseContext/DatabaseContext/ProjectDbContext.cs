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
    }
}
