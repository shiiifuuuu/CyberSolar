using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSolar.DatabaseContext.DatabaseContext;
using CyberSolar.MODEL.Model;

namespace CyberSolar.DAL.Repository
{
    public class PurchaseRepository
    {
        private readonly ProjectDbContext _dbContext;

        public PurchaseRepository()
        {
            _dbContext = new ProjectDbContext();
        }

        public bool Add(PurchaseInformation purchase)
        {
            _dbContext.PurchaseInformations.Add(purchase);

            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(PurchaseInformation purchase)
        {
            PurchaseInformation aPurchase = _dbContext.PurchaseInformations.FirstOrDefault(c => c.Id == purchase.Id);
            if (aPurchase != null)
            {
                _dbContext.PurchaseInformations.Remove(aPurchase);
            }
            return _dbContext.SaveChanges() > 0;
        }

        public List<PurchaseInformation> GetAll()
        {
            return _dbContext.PurchaseInformations.Include("Supplier").Include("Product").ToList();
        }

        public PurchaseInformation GetById(int id)
        {
            return _dbContext.PurchaseInformations.FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<PurchaseInformation> GetIQueryable()
        {
            return _dbContext.PurchaseInformations;
        }
    }
}
