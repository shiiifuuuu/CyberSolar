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
        ProjectDbContext _dbContext = new ProjectDbContext();

        public bool Add(PurchaseInformation purchase)
        {
            return true;
        }

        public bool Delete(PurchaseInformation purchase)
        {
            return true;
        }

        public List<PurchaseInformation> GetAll()
        {
            return new List<PurchaseInformation>();
        }

        public PurchaseInformation GetById(int id)
        {
            return new PurchaseInformation();
        }
    }
}
