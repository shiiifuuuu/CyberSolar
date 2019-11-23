using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSolar.DAL.Repository;
using CyberSolar.MODEL.Model;

namespace CyberSolar.BLL.Manager
{
    public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();

        public bool Add(Category customer)
        {
            return _categoryRepository.Add(customer);
        }

        public bool Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }

        public bool Update(Category customer)
        {
            return _categoryRepository.Update(customer);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }
    }
}
