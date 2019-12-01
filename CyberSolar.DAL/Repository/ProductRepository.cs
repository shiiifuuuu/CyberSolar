using System;
using System.Collections.Generic;
using System.Linq;
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

            return dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            Product aProduct = dbContext.Products.FirstOrDefault(c => c.Id == id);
            dbContext.Products.Remove(aProduct);

            return dbContext.SaveChanges() > 0;
        }

        public bool Update(Product product)
        {
            Product aProduct = dbContext.Products.FirstOrDefault(c => c.Id == product.Id);
            if (aProduct != null)
            {
                aProduct.CategoryId = product.CategoryId;
                aProduct.Name = product.Name;
                aProduct.Code = product.Code;
                aProduct.ReorderLevel = product.ReorderLevel;
                aProduct.Description = product.Description;
            }

            return dbContext.SaveChanges() > 0;
        }

        public List<Product> GetAll()
        {
            return dbContext.Products.Include("Category").ToList();
        }

        public Product GetById(int id)
        {
            return dbContext.Products.FirstOrDefault(c => c.Id == id);
        }
    }
}
