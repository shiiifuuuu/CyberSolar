using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSolar.DatabaseContext.DatabaseContext;
using CyberSolar.MODEL.Model;

namespace CyberSolar.DAL.Repository
{
    public class CustomerRepository
    {
        ProjectDbContext dbContext = new ProjectDbContext();
        public bool Add(Customer customer)
        {
            dbContext.Customers.Add(customer);
            return dbContext.SaveChanges() > 0;

        }
        public bool Delete(int id)
        {
            Customer aCustomer = dbContext.Customers.FirstOrDefault(c => c.Id == id);

            dbContext.Customers.Remove(aCustomer);

            return dbContext.SaveChanges() > 0;
        }
        public bool Update(Customer customer)
        {
            //Method 1 
            Customer aCustomer = dbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);

            if (aCustomer != null)
            {

                aCustomer.Code = customer.Code;
                aCustomer.Name = customer.Name;
                aCustomer.Address = customer.Address;
                aCustomer.Email = customer.Email;
                aCustomer.Contact = customer.Contact;
                aCustomer.LoyaltyPoint = customer.LoyaltyPoint;


            }

            //Method - 2 where update unite not excuitly then we are using 
            //dbContext.Entry(customer).State = EntityState.Modified;

            return dbContext.SaveChanges() > 0;
        }

        public List<Customer> GetAll()
        {
            return dbContext.Customers.ToList();
        }

        public Customer GetBy(int id)
        {
            return dbContext.Customers.First(c => c.Id == id);
        }
    }
}
