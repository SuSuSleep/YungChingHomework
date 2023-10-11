using YungChingHomework.DBModels;
using YungChingHomework.DTOs.Infos;
using YungChingHomework.DTOs.ViewModels;
using YungChingHomework.Repositories;

namespace YungChingHomework.Service
{
    public interface ICustomerService
    {
        public IEnumerable<CustomerView> GetCustomers();
        public CustomerView? GetCustomer(long Id);
        public long CreateCustomer(NewCustomerInfo NewCustomer);
        public bool UpdateCustomer(CustomerInfo UpdatedCustomer);
        public bool DeleteCustomer(long Id);
    }
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<CustomerView> GetCustomers()
        {
            List<Customer> customers = _customerRepository.GetList().ToList();
            List<CustomerView> customerViews = new List<CustomerView>();
            foreach (Customer customer in customers)
            {
                customerViews.Add(new CustomerView(customer));
            }
            return customerViews;
        }
        public CustomerView? GetCustomer(long Id)
        {
            Customer? customer = _customerRepository.Get(Id);
            if (customer == null) return null;
            return new CustomerView(customer);
        }
        public long CreateCustomer(NewCustomerInfo NewCustomer)
        {
            long NewCustomerId = _customerRepository.Create(NewCustomer);
            return NewCustomerId;
        }
        public bool UpdateCustomer(CustomerInfo UpdatedCustomer)
        {
            bool updateSuccess = _customerRepository.Update(UpdatedCustomer);
            return updateSuccess;
        }
        public bool DeleteCustomer(long Id)
        {
            bool deleteSuccess = _customerRepository.Delete(Id);
            return deleteSuccess;
        }
    }
}
