using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSolar.DatabaseContext.DatabaseContext;
using CyberSolar.MODEL.Model;

namespace CyberSolar.DAL.Repository
{
    public class ProductRepository
    {
        ProjectDbContext dbContext = new ProjectDbContext();

        public bool Add(Product product)
        {
            dbContext.Products.Add(product);
            
            return dbContext.SaveChanges()>0; //returns true if condition ok
        }
    }
}
