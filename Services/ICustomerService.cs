using YungChingHomework.DBModels;
using YungChingHomework.DTOs.Conditions;
using YungChingHomework.DTOs.Infos;
using YungChingHomework.DTOs.ViewModels;
using YungChingHomework.Repositories;
using YungChingHomework.Services;

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
        private readonly IOrderService _orderService;
        public CustomerService(ICustomerRepository customerRepository, IOrderService orderService)
        {
            _customerRepository = customerRepository;
            _orderService = orderService;
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
            OrderSearchCondition orderSearchCondition = new OrderSearchCondition
            {
                CustomerId = Id
            };
            List<OrderView> orderViews = _orderService.GetOrders(orderSearchCondition).ToList();
            foreach (OrderView view in orderViews)
            {
                _orderService.DeleteOrder(view.OrderId);
            }
            bool deleteSuccess = _customerRepository.Delete(Id);
            return deleteSuccess;
        }
    }
}
