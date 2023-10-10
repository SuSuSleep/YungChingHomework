namespace YungChingHomework.DTOs.ViewModels
{
    public class CustomerView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
    public class CustomerProductCash
    {
        public string Name { get; set; }
        public IEnumerable<ProductCash>? ProductCash { get; set; }
    }
}
