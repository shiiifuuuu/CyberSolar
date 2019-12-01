using System;
using System.Collections.Generic;
using CyberSolar.DAL.Repository;
using CyberSolar.MODEL.Model;

namespace CyberSolar.BLL.Manager
{
    public class ProductManager
    {
        ProductRepository _productRepository=new ProductRepository();

        public bool Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public bool Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public bool Update(Product product)
        {
            return _productRepository.Update(product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }
    }
}
