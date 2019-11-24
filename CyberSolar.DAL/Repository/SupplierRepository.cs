using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSolar.DatabaseContext.DatabaseContext;
using CyberSolar.MODEL.Model;

namespace CyberSolar.DAL.Repository
{
    public class SupplierRepository
    {
        ProjectDbContext dbContext = new ProjectDbContext();
        public bool Add(Supplier supplier)
        {
            dbContext.Suppliers.Add(supplier);
            return dbContext.SaveChanges() > 0;

        }
        public bool Delete(int id)
        {
            Supplier aSupplier = dbContext.Suppliers.FirstOrDefault(c => c.Id == id);

            dbContext.Suppliers.Remove(aSupplier);

            return dbContext.SaveChanges() > 0;
        }
        public bool Update(Supplier supplier)
        {
            //Method 1 
            Supplier aSupplier = dbContext.Suppliers.FirstOrDefault(c => c.Id == supplier.Id);

            if (aSupplier != null)
            {
                aSupplier.Code = supplier.Code;
                aSupplier.Name = supplier.Name;
                aSupplier.Address = supplier.Address;
                aSupplier.Email = supplier.Email;
                aSupplier.Contact = supplier.Contact;
                aSupplier.ContactPerson = supplier.ContactPerson;
            }

            //Method - 2 where update unite not excuitly then we are using 
            //dbContext.Entry(customer).State = EntityState.Modified;

            return dbContext.SaveChanges() > 0;
        }

        public List<Supplier> GetAll()
        {
            return dbContext.Suppliers.ToList();
        }

        public Supplier GetById(int id)
        {
            return dbContext.Suppliers.First(c => c.Id == id);
        }
    }
}
