using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSolar.DAL.Repository;
using CyberSolar.MODEL.Model;

namespace CyberSolar.BLL.Manager
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();

        public bool Add(PurchaseInformation purchase)
        {
            return _purchaseRepository.Add(purchase);
        }

        public bool Delete(PurchaseInformation purchase)
        {
            return _purchaseRepository.Delete(purchase);
        }

        public List<PurchaseInformation> GetAll()
        {
            return _purchaseRepository.GetAll();
        }

        public PurchaseInformation GetById(int id)
        {
            return _purchaseRepository.GetById(id);
        }
    }
}
