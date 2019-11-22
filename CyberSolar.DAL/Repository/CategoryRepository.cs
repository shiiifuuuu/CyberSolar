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

        public bool Add(Category category)
        {
            dbContext.Categories.Add(category);

            return dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            Category aCategory = dbContext.Categories.FirstOrDefault(c => c.Id == id);
            dbContext.Categories.Remove(aCategory);

            return dbContext.SaveChanges() > 0;
        }

        public bool Update(Category category)
        {
            Category aCategory = dbContext.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (aCategory != null)
            {
                aCategory.Name = category.Name;
                aCategory.Code = category.Code;
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
