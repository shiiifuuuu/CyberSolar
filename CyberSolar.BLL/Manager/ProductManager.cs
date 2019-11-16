using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
