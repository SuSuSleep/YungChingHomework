using YungChingHomework.DBModels;

namespace YungChingHomework.DTOs.ViewModels
{
    public class CustomerView
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public CustomerView(Customer customer) 
        {
            CustomerId = customer.CustomerId;
            CustomerName = customer.CustomerName ?? "";
            Address = customer.Address ?? "";
            City = customer.City ?? "";
            PostalCode = customer.PostalCode ?? "";
            Country = customer.Country ?? "";
        }
    }
    public class CustomerProductCash
    {
        public string Name { get; set; }
        public IEnumerable<ProductCash>? ProductCashs { get; set; }
    }
}
