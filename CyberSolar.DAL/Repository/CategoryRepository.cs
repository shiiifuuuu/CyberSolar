using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSolar.DatabaseContext.DatabaseContext;
using CyberSolar.MODEL.Model;

namespace CyberSolar.DAL.Repository
{
    public class CategoryRepository
    {
        ProjectDbContext dbContext = new ProjectDbContext();

        public bool Add(Category customer)
        {
            dbContext.Categories.Add(customer);

            return dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            Category aCustomer = dbContext.Categories.FirstOrDefault(c => c.Id == id);
            dbContext.Categories.Remove(aCustomer);

            return dbContext.SaveChanges() > 0;
        }

        public bool Update(Category customer)
        {
            Category aCustomer = dbContext.Categories.FirstOrDefault(c => c.Id == customer.Id);
            if (aCustomer != null)
            {
                aCustomer.Name = customer.Name;
                aCustomer.Code = customer.Code;
            }

            return dbContext.SaveChanges() > 0;
        }

        public List<Category> GetAll()
        {
            return dbContext.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return dbContext.Categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
