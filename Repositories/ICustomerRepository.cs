using System.Diagnostics.Metrics;
using YungChingHomework.DBModels;
using YungChingHomework.DTOs.Infos;

namespace YungChingHomework.Repositories
{
    public interface ICustomerRepository
    {
        public IEnumerable<Customer> GetList();
        public Customer? Get(long Id);
        public long Create(NewCustomerInfo NewCustomer);
        public bool Update(CustomerInfo CustomerInfo);
        public bool Delete(long Id);
    }
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> GetList()
        {
            using var dbContext = new NorthwindContext();
            return dbContext.Customers.ToList();
        }
        public Customer? Get(long Id)
        {
            using var dbContext = new NorthwindContext();
            return dbContext.Customers.Where(c => c.CustomerId == Id).FirstOrDefault();
        }
        public long Create(NewCustomerInfo NewCustomer)
        {
            using var dbContext = new NorthwindContext();
            long currentMaxId = dbContext.Customers.Max(c => c.CustomerId);
            currentMaxId += 1;
            Customer customer = new Customer
            {
                CustomerId = currentMaxId,
                CustomerName = NewCustomer.CustomerName,
                ContactName = NewCustomer.ContactName,
                Address = NewCustomer.Address,
                City = NewCustomer.City,
                PostalCode = NewCustomer.PostalCode,
                Country = NewCustomer.Country
            };
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            return currentMaxId;
        }
        public bool Update(CustomerInfo CustomerInfo)
        {
            using var dbContext = new NorthwindContext();
            var customer = dbContext.Customers.Where(c => c.CustomerId.Equals(CustomerInfo.CustomerId)).FirstOrDefault();
            if (customer == null)
            {
                return false;
            }
            customer.CustomerName = CustomerInfo.CustomerName;
            customer.ContactName = CustomerInfo.ContactName;
            customer.Address = CustomerInfo.Address;
            customer.City = CustomerInfo.City;
            customer.PostalCode = CustomerInfo.PostalCode;
            customer.Country = CustomerInfo.Country;
            dbContext.SaveChanges();
            return true;
        }
        public bool Delete(long Id)
        {
            using var dbContext = new NorthwindContext();
            var customer = dbContext.Customers.Where(c => c.CustomerId.Equals(Id)).FirstOrDefault();
            if (customer == null)
            {
                return false;
            }
            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();
            return true;
        }
    }
}
