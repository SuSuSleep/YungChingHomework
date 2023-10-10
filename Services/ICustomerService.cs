using YungChingHomework.DTOs.Infos;
using YungChingHomework.DTOs.ViewModels;

namespace YungChingHomework.Service
{
    public interface ICustomerService
    {
        public IEnumerable<CustomerView> GetCustomers();
        public CustomerView GetCustomer(long Id);
        public long CreateCustomer(NewCustomerInfo NewCustomer);
        public bool UpdateCustomer(CustomerInfo UpdatedCustomer);
        public bool DeleteCustomer(long Id);
    }
}
